
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

typedef struct{
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;//si en la lista hay 5 conectados, de 0 a 4 el siguiente es el 5	
} ListaConectados;


// ------------------------------------------------- Acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int numSocket = 0;
int contador;
int sockets[100];
ListaConectados miLista;


// ------------------------------------------------- MYSQL
MYSQL *conn;
int err;
MYSQL_RES *resultado;
MYSQL_ROW row;



char consulta [512];
char respuesta [512];
char nick[20]; 


//------------------------------------------------------
//------------------------------------------------------ REGISTRO
int id = 0;

int Registrarse (char p[200], char respuesta[20])
{
	//peticion
	char nombre_usuario[20];
	p = strtok(NULL,"/");
	strcpy(nombre_usuario, p);
	
	char contra[20];
	p = strtok(NULL,"/");
	strcpy(contra, p);											
	
	printf("Solicitud de registro recibida: Usuario: %s Contrase�a: %s \n", nombre_usuario, contra);
	
	char consulta[512];
	sprintf(consulta,"SELECT jugadores.nombre_usuario FROM jugadores WHERE jugadores.nombre_usuario = '%s'", nombre_usuario);
	
	err = mysql_query (conn, consulta);
	//printf("el nombre y contraseña son: %s, %s\n" ,nombre_usuario, contra);
	if (err != 0)
	{
		printf ("Error al consultar datos de la base %u %s \n", mysql_errno(conn), mysql_error(conn));
		strcpy(respuesta,"2/ERROR_DB");
		exit(1);
	}
	resultado = mysql_store_result (conn);
	row=mysql_fetch_row(resultado);
	
	// Si el usuario no existe, lo a�adimos
	if (row == NULL) 
	{
		// Obtenemos el mayor ID actual de los jugadores
		sprintf(consulta, "SELECT MAX(jugadores.id) FROM (jugadores)");
		err = mysql_query (conn, consulta);
		if (err != 0)
		{
			printf ("Error al obtener el ID m�ximo %u %s \n", mysql_errno(conn), mysql_error(conn));
			strcpy(respuesta, "2/ERROR_DB");
			exit(1);
		}
		resultado = mysql_store_result (conn);
		row=mysql_fetch_row(resultado);
		
		//convierte ID m�ximo a un n�mero entero y le suma 1 para generar un nuevo ID �nico para el nuevo jugador
		int id = atoi(row[0])+1;
		
		//Registrar jugador 
		sprintf(consulta, "INSERT INTO jugadores (id, nombre_usuario, password) VALUES (%d,'%s','%s')",id, nombre_usuario, contra);
		err = mysql_query (conn, consulta);
		if (err != 0)
		{
			printf ("Error al a�adir el nuevo jugador: %u %s \n", mysql_errno(conn), mysql_error(conn));
			strcpy(respuesta, "2/ERROR_DB");
			exit(1);
		}
		printf("Usuario '%s' registrado correctamente con ID %d.\n", nombre_usuario, id);
		sprintf(respuesta, "2/0"); // Indicar que el registro fue exitoso
	}
	else
	{
		printf("El usuario '%s' ya est� registrado.\n", nombre_usuario);
		sprintf(respuesta, "2/-1"); // Indicar que el usuario ya existe
	}
}

//---------------------------------------------------------
//--------------------------------------------------------- BAJA

void DarseBaja(char p[200], char respuesta[200])
{
	//peticion
	char nombre_usuario[20];
	p = strtok( NULL, "/");
	strcpy(nombre_usuario, p);
	
	char contra[20];
	p = strtok(NULL, "/");
	strcpy(contra, p);
	
	printf("Solicitud para darse de baja: Usuario: %s Contrase�a: %s \n", nombre_usuario, contra);
	
	// Eliminar los datos de jugador de la base de datos
	char consulta[512];
	sprintf(consulta, "DELETE FROM jugadores WHERE (nombre_usuario = '%s' AND password = '%s')", nombre_usuario, contra);
	
	err = mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		strcpy(respuesta, "5/ERROR_DB");
	}
	else 
	{
	printf("Usuario '%s' eliminado de la base de datos\n", nombre_usuario);
	sprintf(respuesta, "5/DELETED_SUCCESSFUL");
	}
}

//---------------------------------------------------------
//--------------------------------------------------------- LOGIN

int LogIn(char p[200], char respuesta[20])
{
	//peticion
	char nombre_usuario[20];
	p = strtok( NULL, "/");
	strcpy(nombre_usuario, p);
	
	char contra[20];
	p = strtok(NULL, "/");
	strcpy(contra, p);
	
	printf("Solicitud de inicio de sesi�n recibida: Usuario: %s Contrase�a: %s \n", nombre_usuario, contra);

	//Primero miramos ya hay un usuario con el mismo nombre conectado
	int resp = DamePosicionNombre(nombre_usuario);

	if (resp != -1) {
		printf("Jugador ya conectado\n");
		strcpy(respuesta, "1/ALREADY_IN");
	} else {
		// Consultamos si el usuario existe 
		char consulta_usuario[512];
		sprintf(consulta_usuario, "SELECT nombre_usuario FROM jugadores WHERE nombre_usuario = '%s'", nombre_usuario);
	
		err = mysql_query(conn, consulta_usuario);
		if (err != 0) {
			printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			strcpy(respuesta, "1/ERROR_DB");
			exit(1);
		}
	
		// Almacenamos y verificamos el resultado
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
	
	
		if (row == NULL) {
			// No se encontro el usuario
			printf("El usuario '%s' no existe.\n", nombre_usuario);
			strcpy(respuesta, "1/NO_USER");
		}
		else 
		{
			// Si el usuario existe, verificamos la contrase�a
			char consulta_contra[512];
			sprintf(consulta_contra, "SELECT nombre_usuario FROM jugadores WHERE nombre_usuario = '%s' AND password = '%s'", nombre_usuario, contra);
		
			err = mysql_query(conn, consulta_contra);
			if (err != 0) {
				printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				strcpy(respuesta, "1/ERROR_DB");
				exit(1);
			}
		
			// Verificamos si hay resultados
			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);
		
			if (row == NULL) {
				// El usuario existe, pero la contrase�a es incorrecta
				strcpy(respuesta, "1/WRONG_PASSWORD");
			} else {
				// Usuario y contrase�a correctos
			
				pthread_mutex_lock( &mutex );
				int success = PonConectado(nombre_usuario, &sockets[numSocket-1]);
				pthread_mutex_unlock( &mutex );

				if (success == 0) {
					strcpy(respuesta, "1/LOGIN_SUCCESSFUL");
				} else {
					strcpy(respuesta, "1/ERROR_LIST");
				}
			}
		}
	}
}

//--------------------------------------------------	
//-------------------------------------------------- CONECTADOS

//A�ade nuevo conectados
//retorna 0 si ok y -1 si la lista ya estaba llena 

int PonConectado (char nombre[20], int *socket)
{
	if (miLista.num == 100)
		return -1;
	else {
		strcpy (miLista.conectados[miLista.num].nombre, nombre);
		miLista.conectados[miLista.num].socket = *socket;
		miLista.num++;
		return 0;
	}
}


// Pone en conectados los nombres de todos los conectados separados por "/". 
// primero pone el numero de conectados

void DameConectados (char conectado[300])
{
	char conectados[300];
	sprintf(conectados, "%d/", miLista.num);
	int i;
	for (i = 0; i < miLista.num; i++){
		sprintf(conectados, "%s%s/", conectados, miLista.conectados[i].nombre);
	}
	//conectados[strlen(conectados) - 1] = '\0';
	//strcat(conectados, "/");	
	printf("Conectados:%s \n", conectados);
	strcpy(conectado, conectados);
}

// Devuelve la posicion en la lista o -1 si no est� en la lista

int DamePosicionNombre (char name[20]) {
	
	int i = 0;
	int encontrado = 0;
	while ((i < miLista.num) && encontrado == 0)
	{
		if (strcmp(miLista.conectados[i].nombre, name) == 0)
			encontrado = 1;
		if (encontrado == 0)
			i++;
	}
	if (encontrado == 1)
		return i;
	else
		return -1;
}

int DamePosicionSocket (int *socket) {
	
	int i = 0;
	int encontrado = 0;
	while ((i< miLista.num) && encontrado == 0)
	{
		if (miLista.conectados[i].socket == *socket)
			encontrado = 1;
		if (encontrado == 0)
			i++;
	}
	if (encontrado == 1)
		return i;
	else
		return -1;
}

int QuitarJugador(int *socket) {
	//Busca el socket del jugador per treure'l de la llista de connectats
	int found = 0;

	for (int i = 0; i < miLista.num && !found; i++) {
		if (miLista.conectados[i].socket == *socket) {
			for (int j = 0; j < numSocket && !found; j++) {
				if (sockets[j] == *socket) {
					pthread_mutex_lock( &mutex );
					sockets[j] = sockets[numSocket - 1];
					numSocket--;
					found = 1;
				}
			}

			miLista.conectados[i] = miLista.conectados[miLista.num-1];
			miLista.num = miLista.num - 1;
			pthread_mutex_unlock( &mutex );
		}
	}

	if (found) {
		return 1;	//True
	}

	return 0;		//False
}

//--------------------------------------------------------
//-------------------------------------------------------- PETICIONES CLIENTES

void *AtenderCliente (void *socket)
{
	
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	
	
	char nombre [20];
	char conectado[200];
	char peticion[512];
	char respuesta[512];
	int ret;
	
	/*//inizializamos conexion con la base de datos
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;// Estructura especial para almacenar resultados de consultas 
	MYSQL_ROW row;
	*/
	
	conn = mysql_init(NULL);//Creamos una conexion al servidor MYSQL 
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "TG8",0, NULL, 0);

	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// Bucle que atiende las peticiones hasta que el cliente se desconecte
	int terminar = 0;		
	while (terminar == 0)
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
		
		///////////////////////////////////////////////////////////////
		if (codigo ==0) {	// CONUSLTA 0 : DESCONECTAR SERVIDOR
			int conf = QuitarJugador(&sock_conn);
			if (conf == 1) {
				printf("Usuari eliminat de la llista\nUsuaris restants:\n");
				for (int i = 0; i < miLista.num; i++) {
					printf("Nombre: %s\nSocket: %d\n\n", miLista.conectados[i].nombre, miLista.conectados[i].socket);
				}
			}

			char conectados [300];
			
			DameConectados (conectados);
			
			sprintf (respuesta, "3/%s", conectados);
			printf("%s", respuesta);

			for (int i = 0; i < numSocket; i++) {
				write (sockets[i], respuesta, strlen(respuesta));
			}

			terminar = 1;
		}
			
		
		//////////////////////////////////////////////////////////////
		else if (codigo == 1) // CONSULTA 1 : LOGIN
		{	
			LogIn(p, respuesta);
			
			printf("%s\n", respuesta); // Escribir respuesta del cliente por consola "LOGIN_SUCCESSFUL"
			write(sock_conn, respuesta, strlen(respuesta));

			char conectados [300];
			
			DameConectados (conectados);
			
			sprintf (respuesta, "3/%s", conectados);
			printf("%s", respuesta);

			for (int i = 0; i < numSocket; i++) {
				write (sockets[i], respuesta, strlen(respuesta));
			}
		}
		///////////////////////////////////////////////////////////////
		else if (codigo== 2) // CONSULTA 2 : REGISTRO 
		{
			//pthread_mutex_lock(&mutex);
			Registrarse(p, respuesta);
			//pthread_mutex_unlock(&mutex);
			
			printf("%s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
			
		}
			/////////////////////////////////////////////////////////////////	
		else if (codigo == 5) // CONSULTA 5 : DARSE DE BAJA
		{
			DarseBaja(p, respuesta);
    
			printf("Resposta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));

			int conf = QuitarJugador(&sock_conn);
			if (conf == 1) {
				printf("Usuari eliminat de la llista\nUsuaris restants:\n");
				for (int i = 0; i < miLista.num; i++) {
					printf("Nombre: %s\nSocket: %d\n\n", miLista.conectados[i].nombre, miLista.conectados[i].socket);
				}
			}

			char conectados [300];
			
			DameConectados (conectados);
			
			sprintf (respuesta, "3/%s", conectados);
			printf("%s", respuesta);

			for (int i = 0; i < numSocket; i++) {
				write (sockets[i], respuesta, strlen(respuesta));
			}

			terminar = 1;
			
		}
		/////////////////////////////////////////////////////////////////	
		else if (codigo == 6) // CONSULTA 6 : INVITACION
		{
			char nombre1[20];	//Persones que són convidades
			char nombre2[20];
			char nombre3[20];
			char nombre4[20];	//Persona que convida
			int turnos[3];
			int numJugador;
			int found = 0;

			p = strtok(NULL, "/");
			printf("numJugadors: %s\n", p);
			numJugador = atoi(p);
			p = strtok(NULL, "/");
			strcpy(nombre1, p);

			switch (numJugador) {
				case 1:
					p = strtok(NULL, "/");
					strcpy(nombre4, p);

					p = strtok(NULL, "/");
					turnos[0] = atoi(p);

					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre1, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[0]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					break;
				case 2:
					p = strtok(NULL, "/");
					strcpy(nombre2, p);
					p = strtok(NULL, "/");
					strcpy(nombre4, p);

					p = strtok(NULL, "/");
					turnos[0] = atoi(p);
					p = strtok(NULL, "/");
					turnos[1] = atoi(p);


					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre1, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[0]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre2, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[1]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					break;

				case 3:
					p = strtok(NULL, "/");
					strcpy(nombre2, p);
					p = strtok(NULL, "/");
					strcpy(nombre3, p);
					p = strtok(NULL, "/");
					strcpy(nombre4, p);

					p = strtok(NULL, "/");
					turnos[0] = atoi(p);
					p = strtok(NULL, "/");
					turnos[1] = atoi(p);
					p = strtok(NULL, "/");
					turnos [2] = atoi(p);

					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre1, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[0]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre2, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[1]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					for (int i = 0; i < miLista.num && found == 0; i++) {
						if (strcmp(nombre3, miLista.conectados[i].nombre) == 0) {
							sprintf(respuesta, "6/%s/%d", nombre4, turnos[2]);
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}

					break;
			}
			printf("%s\n", respuesta);
		}
		/////////////////////////////////////////////////////////////////	
		else if (codigo == 7) // CONSULTA 7 : CHAT
		{
			char nom[20];
			p = strtok(NULL, "/");
			strcpy(nom, p);
			char message[512];
			p = strtok(NULL, "/");
			strcpy(message, p);

			sprintf(respuesta, "%d/%s/%s", codigo, nom, message);
			printf("%s\n", respuesta);
			for (int i = 0; i < numSocket; i++) {
				write(sockets[i], respuesta, strlen(respuesta));
			}
		}

		/////////////////////////////////////////////////////////////////	
		else if (codigo == 8) // CONSULTA 8 : ACEPTAR/CANCELAR INVITACION
		{
			char res[10];
			char nom[20];
			char convidat[20];

			p = strtok(NULL, "/");
			strcpy(res, p);

			p = strtok(NULL, "/");
			strcpy(nom, p);

			p = strtok(NULL, "/");
			strcpy(convidat, p);

			int resp = DamePosicionNombre(nom);	//Busquem el socket de la persona que convida per dir-li si hem acceptat o no

			if (strcmp(res, "OK") == 0) {
				sprintf(respuesta, "8/OK/%s", convidat);
			}
			else {
				sprintf(respuesta, "8/NO/%s", convidat);
			}

			printf("%s\n", respuesta);
			write(miLista.conectados[resp].socket, respuesta, strlen(respuesta));
		}

		/////////////////////////////////////////////////////////////////	
		else if (codigo == 9) // CONSULTA 9 : EMPEZAR EL JUEGO
		{
			int nJugadores;
			int found = 0;
			char J1[20];
			char J2[20];
			char J3[20];
			char J4[20];
			int j = 0;

			p = strtok(NULL, "/");
			nJugadores = atoi(p);

			sprintf(respuesta, "9/%d", nJugadores);

			for (int i = 0; i < nJugadores; i++) {
				p = strtok(NULL, "/");
				sprintf(respuesta, "%s/%s", respuesta, p);
				j++;

				switch (j) {
					case 1:
						strcpy(J1, p);
						break;

					case 2:
						strcpy(J2, p);
						break;

					case 3:
						strcpy(J3, p);
						break;

					case 4:
						strcpy(J4, p);
						break;
				}
			}

			printf("%s\n", respuesta);

			for (int i = 0; i < miLista.num; i++) {
				if (strcmp(miLista.conectados[i].nombre, J1) == 0) {
					write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
				}
				else if (strcmp(miLista.conectados[i].nombre, J2) == 0) {
					write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
					if (nJugadores == 2) {
					}
				}
				else if (nJugadores > 2) {
					if (strcmp(miLista.conectados[i].nombre, J3) == 0) {
						write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
					}
					else if (nJugadores > 3) {
						if (strcmp(miLista.conectados[i].nombre, J4) == 0) {
							write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
						}
					}
				}
			}
		}
		
		///////////////////////////////////////////////////////////////
		else if (codigo == 10) // CONSULTA 10 : DEVUELVE JUGADORES QUE JUGARON UN DIA INTROCUDIO POR TECLADO
		{
			char fecha[30];
			p = strtok(NULL, "/"); 
			strcpy(fecha,p);
			char consulta[512];
			char nombres[50];
			
			/*sprintf (consulta, "SELECT jugadores.nombre_usuario "
			"FROM jugadores "
			"JOIN info_partida ON (info_partida.jugador1 = jugadores.id OR "
			"info_partida.jugador2 = jugadores.id OR "
			"info_partida.jugador3 = jugadores.id OR "
			"info_partida.jugador4 = jugadores.id) "
			"JOIN partidas ON partidas.id = info_partida.partida "
			"WHERE partidas.fecha = '%s'",fecha);*/
			
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
				sprintf (respuesta, "10/ERROR_DB");
			
			else 
			{
				strcpy(respuesta, "10/");
				while (row!=NULL) 
				{
					strcpy(nombres, row[0]);
					row = mysql_fetch_row(resultado);
					sprintf(respuesta, "%s%s/", respuesta, nombres);
				}
			}	
			printf("Consulta de jugadores que jugaron el %s: %s\n", fecha, respuesta);
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		//////////////////////////////////////////////////////////
		else if (codigo ==11)// CONSULTA 11: DimeGanadores: que jugadores ganaron ese dia
		{
			char fecha[30];
			p = strtok(NULL, "/"); 
			strcpy(fecha,p);
			char consulta[562];
			char nombres[50];
			
			sprintf(consulta, "SELECT DISTINCT jugadores.nombre_usuario "
					"FROM jugadores, partidas "
					"WHERE partidas.fecha = '%s' AND partidas.ganador = jugadores.nombre_usuario", fecha); //jugadores.id
			
			
			err=mysql_query (conn, consulta);
			if (err!=0) {	
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				strcpy(respuesta, "11/ERROR_DB");
			}

			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row == NULL){
				printf("Error al almacenar el resultado de la consulta: %u %s\n", mysql_errno(conn), mysql_error(conn));
				strcpy(respuesta, "11/ERROR_DB");
			}
			else 
			{
				strcpy(respuesta, "11/");
				while (row!=NULL) 
				{
					strcpy(nombres, row[0]);
					row = mysql_fetch_row(resultado);
					sprintf(respuesta, "%s%s/", respuesta, nombres);
				}
			}
			printf("Consulta de jugadores que ganaron el %s: %s\n", fecha, respuesta);
			write (sock_conn, respuesta, strlen(respuesta));	
		}
		
		
		//////////////////////////////////////////////////////////////	
		//-Consulta Duracion total partidas-
		else if (codigo ==12)
		{
			
			char nombre_usuario[30];
			p = strtok(NULL, "/"); 
			strcpy(nombre_usuario, p);
			
			char consulta[512];
			printf("El nombre del jugador seleccionado es: '%s'\n", nombre_usuario);
			
			
			sprintf (consulta, "SELECT SUM(partidas.duracion) FROM (partidas) WHERE partidas.ganador = '%s'",nombre_usuario);
			
			err= mysql_query (conn, consulta);
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
				strcpy(respuesta, "12/ERROR_DB");
			}
			
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			
			if (row[0]==NULL)
				sprintf (respuesta, "12/ERROR_DB");
			
			else
				sprintf (respuesta, "12/%s", row[0]);
			
			printf("%s\n", respuesta);
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		/////////////////////////////////////////////////////////////////
		else if ((codigo ==1) || (codigo==2) || (codigo==3) || (codigo==4) || (codigo==10) || (codigo==11)|| (codigo==12))
		{
			pthread_mutex_lock( &mutex );
			contador=contador+1;
			pthread_mutex_unlock( &mutex );
		}	
		
	}
	close(sock_conn);	// Se acabo el servicio para este cliente
}


//-------------------------------------------------------------------------------------------------
//----------------------------------MAIN PROGRAM---------------------------------------------------
int main(int argc, char **argv)
{	
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	
	// INICIALIZACIONES socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	
	// Hacemos el bind al puerto
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY); // asociar socket a cualquier IP
	serv_adr.sin_port = htons(50089); // establecemos el puerto de escucha
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind\n");
	
	if (listen(sock_listen, 100) < 0)
		printf("Error en el Listen");
	
	contador =0;
	pthread_t thread; //creo la estuctura de threads y declaro un vector de threads, en creador de threads incluyo el que estamos usando ahora
	
	// bucle infinito
	for(;;){ 
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[numSocket] = sock_conn;//sock_conn es el socket que usaremos para este cliente
		pthread_create (&thread, NULL, AtenderCliente, &sockets[numSocket]);// Crear thead y decirle lo que tiene que hacer
		numSocket++;
	}
}

