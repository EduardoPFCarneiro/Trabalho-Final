create database CaixaControl_bd;
use CaixaControl_bd;

CREATE TABLE Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(100) NOT NULL,
cpf_fun varchar(11)
);	

create table Fornecedor(
id_for int primary key auto_increment,
razaoSocial_for varchar(100),
nome_for varchar(100),
cnpj_for varchar(50),
ativo_for bool,
atividadeEco_for varchar(100),
telefone varchar(15),
email_for varchar(100)
);

CREATE TABLE Caixa(
id_cai int auto_increment primary key,
saldoInicial_cai double NOT NULL,
totalEntradas_cai double,
totalSaidas_cai double,
status_cai varchar(50),
id_fun_fk int not null,
FOREIGN KEY(id_fun_fk)REFERENCES Funcionario(id_fun)
);

CREATE TABLE Despesa(
id_des int primary key auto_increment,
valor_des double,
dataVencimento_des date,
dataPagamento_des date,
status_des bool,
id_cai_fk int not null,
id_for_fk int NOT NULL,
Foreign Key(id_for_fk)References Fornecedor(id_for),
FOREIGN KEY(id_cai_fk)REFERENCES Caixa(id_cai)
);

CREATE TABLE Recebimento(
id_rec int primary key auto_increment,
valor_rec double,
dataVencimento_rec date,
dataPagamento_rec date,
status_rec varchar(50),
id_cai_fk int not null,
FOREIGN KEY(id_cai_fk)REFERENCES Caixa(id_cai)
);


Insert into Funcionario values(0, 'Eduardo', '98654594268');
Insert into Funcionario values(0, 'Elias', '12332112333');
Insert into Funcionario values(0, 'Kamila', '45642346896');

