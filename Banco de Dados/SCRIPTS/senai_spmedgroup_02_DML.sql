USE SP_MEDICAL_GROUP;
GO

INSERT INTO TipoUsuario (tituloTipoUsuario)
VALUES ('Administrador'), ('M�dico'), ('Paciente');
GO

INSERT INTO Clinica (nomeClinica, razaoSocial, cnpj, endereco, horarioAbertura, horarioEncerramento) 
VALUES ('Clinica Possarle', 'SP Medical Group', '86400902000130', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', '07:00', '18:00' );
GO


INSERT INTO Situacao (descricao)
VALUES ('Realizada'), ('Cancelada'), ('Agendada');
GO

--FEITO ATE AQUI

--INSERT INTO Especialidade (tituloEspecialidade)
--Atrav�s de Importa��o


--INSERT INTO Usuario
--Atrav�s de Importa��o

INSERT INTO Medico(idUsuario, nomeMedico, idEspecialidade, crm)
VALUES (1, 'Ricardo Lemos',2, '54356SP' ), (2, 'Roberto Possarle', 17, '53452SP'), (3, 'Helena Strada', 16, '65463SP');
GO

INSERT INTO Administrador(idUsuario, nomeAdministrador)
VALUES (11, 'Sarah');
GO


--INSERT INTO Paciente
--Atrav�s de Importa��o

--INSERT INTO Consulta
--Atrav�s de Importa��o