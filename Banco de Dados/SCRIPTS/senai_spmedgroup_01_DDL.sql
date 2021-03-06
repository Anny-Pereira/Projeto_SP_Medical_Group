CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO

CREATE TABLE TipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
tituloTipoUsuario VARCHAR(20) UNIQUE NOT NULL
);
GO

CREATE TABLE Clinica(
idClinica INT PRIMARY KEY IDENTITY(1,1),
nomeClinica VARCHAR(60) NOT NULL,
razaoSocial VARCHAR(100) NOT NULL,
cnpj CHAR(14) UNIQUE NOT NULL,
endereco VARCHAR(200) NOT NULL,
horarioAbertura TIME,
horarioEncerramento TIME
);
GO

CREATE TABLE Especialidade(
idEspecialidade  INT PRIMARY KEY IDENTITY(1,1),
tituloEspecialidade VARCHAR(50) NOT NULL 
);
GO

CREATE TABLE Situacao(
idSituacao INT PRIMARY KEY IDENTITY(1,1),
descricao VARCHAR(15) UNIQUE NOT NULL
);
GO

CREATE TABLE Usuario(
idUsuario INT PRIMARY KEY IDENTITY(1,1),
idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
idClinica INT FOREIGN KEY REFERENCES Clinica(idClinica),
email VARCHAR(200) UNIQUE NOT NULL,
senha VARCHAR(15) NOT NULL
);
GO

CREATE TABLE Medico(
idMedico INT PRIMARY KEY IDENTITY(1,1),
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
idEspecialidade INT FOREIGN KEY REFERENCES Especialidade(idEspecialidade),
nomeMedico VARCHAR(30) NOT NULL,
crm VARCHAR(8) UNIQUE NOT NULL
);
GO

CREATE TABLE Paciente(
idPaciente INT PRIMARY KEY IDENTITY(1,1),
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
nomePaciente VARCHAR(30) NOT NULL,
dataNascimento DATE NOT NULL,
telefone VARCHAR (15) UNIQUE,
rg CHAR(9) UNIQUE NOT NULL,
cpf CHAR(11) UNIQUE NOT NULL,
endereco VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Administrador(
idAdministrador  INT PRIMARY KEY IDENTITY(1,1),
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
nomeAdministrador VARCHAR(30) NOT NULL
);
GO

CREATE TABLE Consulta(
idConsulta  INT PRIMARY KEY IDENTITY(1,1),
idPaciente INT FOREIGN KEY REFERENCES Paciente(idPaciente),
idMedico INT FOREIGN KEY REFERENCES Medico(idMedico),
idSituacao INT FOREIGN KEY REFERENCES Situacao(idSituacao) DEFAULT (3),
dataConsulta DATETIME NOT NULL,
descricao VARCHAR(210)
);
GO

