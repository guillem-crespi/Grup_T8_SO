DROP DATABASE IF EXISTS BBDD;
CREATE DATABASE BBDD;

USE BBDD;

CREATE TABLE jugadores(

	id INT NOT NULL,
	nombre_usuario VARCHAR(15),
	password VARCHAR(10),
	PRIMARY KEY(id)

)ENGINE=InnoDB;


CREATE TABLE partidas(

	id INT NOT NULL,
	fecha VARCHAR(12),
	hora VARCHAR(10),
	duracion FLOAT,
	ganador VARCHAR(15),
	PRIMARY KEY(id)

)ENGINE=InnoDB;

CREATE TABLE info_partida(

	jugador1 INT NOT NULL,
	jugador2 INT NOT NULL,
	jugador3 INT,
	jugador4 INT,
	partida INT NOT NULL,
	puntos INT NOT NULL,
	FOREIGN KEY (jugador1) REFERENCES jugadores(id),
	FOREIGN KEY (jugador2) REFERENCES jugadores(id),
	FOREIGN KEY (jugador3) REFERENCES jugadores(id),
	FOREIGN KEY (jugador4) REFERENCES jugadores(id),
	FOREIGN KEY (partida) REFERENCES partidas(id)

)ENGINE=InnoDB;


INSERT INTO jugadores(id, nombre_usuario, password)

VALUES(1,'Alex','1234');


INSERT INTO jugadores(id, nombre_usuario, password)

VALUES(2,'Pepe','1111');


INSERT INTO jugadores(id, nombre_usuario, password)

VALUES(3,'Juan','0000');


INSERT INTO jugadores(id, nombre_usuario, password)

VALUES(4,'Carla','2222');


SELECT * FROM jugadores;



INSERT INTO partidas(id, fecha, hora, duracion, ganador)

VALUES(1,'10-11-2024','09:11',4.6,'Carla');


INSERT INTO partidas(id, fecha, hora, duracion, ganador)

VALUES(2,'10-06-2024','17:11',2.03,'Carla');


INSERT INTO partidas(id, fecha, hora, duracion, ganador)

VALUES(3,'02-02-2024','23:41',7.0,'Juan');


INSERT INTO partidas(id, fecha, hora, duracion, ganador)

VALUES(4,'29-12-2024','19:01',3.42,'Alex');


SELECT * FROM partidas;



INSERT INTO info_partida(jugador1, jugador2, jugador3, jugador4, partida, puntos)

VALUES(1,2,3,4,1,10);


INSERT INTO info_partida(jugador1, jugador2, jugador3, partida, puntos)

VALUES(1,3,4,2,9);


INSERT INTO info_partida(jugador1, jugador2, partida, puntos)

VALUES(2,4,3,10);


INSERT INTO info_partida(jugador1, jugador2, jugador3, jugador4, partida, puntos)

VALUES(1,2,3,4,4,11);


SELECT * FROM info_partida;
