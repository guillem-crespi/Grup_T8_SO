
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


typedef struct{
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;//sie n la lista hay 5 conectados, de 0 a 4 el siguiente es el 5
	
} ListaConectados;


	
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i;
int sockets[100];
ListaConectados miLista;

MYSQL *conn;
int err;
MYSQL_RES *resultado;
MYSQL_ROW row;

char consulta [512];
char respuesta [512];
char nick[20]; 

int contador;	
	
int PonConectado (ListaConectados *lista, char nombre[20], int socket){
	/*Aï¿¯ïŸ¿ïŸ±ade nuevp conectados. retorna 0 si ok y -1 si la 
	lista ya estaba llena y no lo ha podido hacer
	*/
	if (lista->num == 100)
		return -1;
	else {
		strcpy (lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}

int DamePosicion (ListaConectados *lista, int socket){
	
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (lista->conectados[i].socket==socket)
			encontrado =1;
		if (!encontrado)
			i++;
		
		
	}
	if (encontrado)
		return i;
	else
		return -1;
	
}

void DameConectados (ListaConectados *lista, char conectados[300])
{// pone en conectados los niombres de todos los conectados separados por "/". Primero pone el numero de conectados
	sprintf(conectados, "%d/", lista->num);
	int i;
	for (i = 0; i < lista->num; i++)
		sprintf(conectados, "%s%s/", conectados, lista->conectados[i].nombre);
	
	conectados[strlen(conectados) - 1] = '\0';
	strcat(conectados, "/");	
}

int id = 0;



int Registrarse (char nombre_usuario[20], char contra[20], char respuesta[20])
{
	
	printf("%s", nombre_usuario);
	
	printf("%s", contra);
	
	printf("%s", respuesta);
	
	printf("estoy en registrar\n");
	printf("1%s", consulta);
	
	sprintf(consulta,"SELECT jugadores.nombre_usuario FROM jugadores WHERE jugadores.nombre_usuario = '%s'", nombre_usuario);
	printf("2%s", consulta);
	
	err = mysql_query (conn, consulta);
	printf("el nombre y contrase�a son: %s, %s\n" ,nombre_usuario, contra);
	if (err != 0)
	{
		printf("hola");
		printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	resultado = mysql_store_result (conn);
	row=mysql_fetch_row(resultado);
	printf("hola1");
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
		printf("Su nombre y contrase�a son: %s, %s\n" ,nombre_usuario, contra);
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






	
	
	

void *AtenderCliente (void *socket)
{
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "CM_BD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	


		int terminar =0;	
		
		
		while (terminar ==0)
		{
			
			// Ahora recibimos la peticion
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a�adirle la marca de fin de string 
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
			
			else if (codigo== 4)//lista conectados
			{
				
				char conectados [300];
				DameConectados (&miLista, conectados);
				printf("lista de conectados: %s\n", conectados);
				
				
				for (i=0; i < miLista.num; i++)
				{
					write (miLista.conectados[i].socket, conectados, strlen(conectados));
				}
				
				
				printf ("%s", respuesta);
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
				printf("Nickname: %s Contrase�a: %s \n", nombre_usuario, contra);
				
				Registrarse(nombre_usuario, contra, respuesta);
				printf("3%s", respuesta);
				// Enviamos la respuesta
				write (sock_conn,respuesta , strlen(respuesta));
			}
					 
		}
		
		
		// Se acabo el servicio para este cliente
		close(sock_conn);
	}
	
	

int main(int argc, char **argv)
{	
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
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
	serv_adr.sin_port = htons(9010);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	contador =0;
	int i;
	
	int sockets[100];
	pthread_t thread; //creo la estuctura de threads y declaro un vector de threads, en creador de threads incluyo el que estamos usando ahora
	i=0;
	
	
	for(;;){ 
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		// Crear thead y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
}

	
	
	
	
