
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <stdlib.h>
#include <pthread.h>


int main(int argc, char **argv)
{	
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	//char consulta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9090);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	
	
	////conexioncon base de datos
	//inizializamos conexion con la base de datos
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexin
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDD",0, NULL, 0);
	
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	
	int i;
	// bucle infinito
	

	
	for(;;){ 
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
	
		
		int Registrarse (char nombre_usuario[20], char contra[20], char respuesta[20])
		{
			
			char consulta [512];
			
			sprintf(consulta, "SELECT jugadores.nombre_usuario FROM jugadores WHERE jugadores.nombre_usuario = '%s'", nombre_usuario);
			err = mysql_query (conn, consulta);
			printf("Su nombre y contraseña son: %s, %s\n" ,nombre_usuario, contra);
			if (err != 0)
			{
				printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			resultado = mysql_store_result (conn);
			row=mysql_fetch_row(resultado);
			
			if (row == NULL)
			{
				sprintf(consulta, "SELECT MAX(jugadores.id) FROM (jugadores)");
				err = mysql_query (conn, consulta);
				if (err != 0)
				{
					printf("hola\n");
					printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result (conn);
				row=mysql_fetch_row(resultado);
				
				
				int id = atoi(row[0])+1;
				printf("%d\n", id);
				sprintf(consulta, "INSERT INTO jugadores (id, nombre_usuario, password) VALUES (%d,'%s','%s')",id, nombre_usuario, contra);
				printf("%s\n", consulta);
				err = mysql_query (conn, consulta);
				printf("Su nombre y contraseña son: %s, %s\n" ,nombre_usuario, contra);
				if (err != 0)
				{
					printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				
				sprintf(respuesta, "0");
			}
			else
			{
				sprintf(respuesta, "-1");
			}
		}
		
		
		
		
		
		int terminar =0;	
		
		
		while (terminar ==0)
		{
			
			// Ahora recibimos la peticion
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que añadirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			
			printf ("Peticion: %s\n",peticion);
			
			// vamos a ver que quieren
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
			
			
			
			
			if (codigo ==0)
				terminar=1;
			
			
			//Log In
			else if (codigo ==1) //log in
			{
				printf("Has iniciado sesion como:\n");
				char nombre_usuario[20];
				p = strtok( NULL, "/");
				strcpy(nombre_usuario, p);
				char contra[20];
				p = strtok(NULL, "/");
				char consulta[512];
				strcpy(contra, p);
				printf("%s", nombre_usuario);
				printf("%s", contra);
				
				
				
				sprintf(consulta, "SELECT jugadores.nombre_usuario FROM jugadores WHERE jugadores.nombre_usuario = '%s' AND jugadores.password = '%s'", nombre_usuario, contra);
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				printf("consulta: %s\n",consulta);
				
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				
				if (row == NULL)
				{	
					sprintf(respuesta, "NO");
				}
				else
				{
					strcpy(respuesta, "SI");
				}
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos la respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			//Consulta que jugadores jugaron ese dia
			else if (codigo ==2)
			{
				char fecha[30];
				p = strtok(NULL, "/"); 
				strcpy(fecha,p);
				char consulta[512];
				char nombres[50];
				
				sprintf (consulta, "SELECT jugadores.nombre_usuario FROM jugadores,partidas,info_partida WHERE partidas.fecha = '%s' AND partidas.id=info_partida.partida AND (info_partida.jugador1 = jugadores.id OR info_partida.jugador2 = jugadores.id OR info_partida.jugador3 = jugadores.id OR info_partida.jugador4 = jugadores.id)",fecha);
				
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				printf("consulta: %s\n",consulta);
				
				
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				
				
				if (row == NULL)
					sprintf (resultado, "NO");
				
				else 
				{
					while (row!=NULL) 
					{
						sprintf (nombres, row[0]);
						row = mysql_fetch_row(resultado);
						sprintf(resultado, "%s%s/ \n", resultado, nombres);
					}
				}		
				
				write (sock_conn,resultado, strlen(resultado));
				
				
			}
			
			//-Consulta Duracion total partidas-
			else if (codigo ==3)
			{
				
				
				char nombre_usuario[30];
				p = strtok(NULL, "/"); 
				strcpy(nombre_usuario, p);
				char consulta[512];
				printf("el nick seleccionado es: '%s'\n", nombre_usuario);
				
				
				sprintf (consulta, "SELECT SUM(partidas.duracion) FROM (partidas) WHERE partidas.ganador = '%s'",nombre_usuario);
				
				err= mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				printf("consulta: %s\n",consulta);
				
				
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				if (row[0]==NULL)
					sprintf (respuesta, "NO");
				
				
				else 
					sprintf (respuesta, row[0]);
				
				
				printf("2%s", respuesta);
				write (sock_conn,respuesta, strlen(respuesta));
			}
			
			else if (codigo== 5) //Registrarse
			{
				char nombre_usuario[20];
				char contra[20];
				p = strtok(NULL, "/");
				strcpy(nombre_usuario, p);
				p = strtok(NULL, "/");
				strcpy(contra, p);
				printf("Nickname: %s Contraseña: %s \n", nombre_usuario, contra);
				
				Registrarse(nombre_usuario, contra, respuesta);
				printf("3%s", respuesta);
				// Enviamos la respuesta
				write (sock_conn,respuesta , strlen(respuesta));
			}
					 
		}
		
		
		// Se acabo el servicio para este cliente
		close(sock_conn);
	}
	
	
}


	
	
	
	
	
