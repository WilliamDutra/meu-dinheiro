create table conta 
(
	id serial primary key,
	nome varchar(100) not null,
	criado_em timestamp not null
);

create table despesa
(
	id serial primary key,
	nome varchar(150) not null,
	valor money not null,
	data_lancamento timestamp,
	tipo_lancamento_id int,
	constraint fk_tipo_lancamento_id foreign key (tipo_lancamento_id) references tipo_despesa(id)
);

create table tipo_despesa
(
	id int primary key,
	nome varchar(150) not null
);