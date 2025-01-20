\c postgres
drop database foot;
create database foot;
\c foot

CREATE TABLE team(
                     id_team SERIAL,
                     team VARCHAR(50)  NOT NULL,
                     PRIMARY KEY(id_team)
);

CREATE TABLE game(
                     id_game SERIAL,
                     score_outsider SMALLINT NOT NULL,
                     score_insider SMALLINT NOT NULL,
                     id_insider INTEGER NOT NULL,
                     id_outsider INTEGER NOT NULL,
                     arret_outsider INTEGER NOT NULL,
                     arret_insider INTEGER NOT NULL,
                     PRIMARY KEY(id_game),
                     FOREIGN KEY(id_insider) REFERENCES team(id_team),
                     FOREIGN KEY(id_outsider) REFERENCES team(id_team)
);
