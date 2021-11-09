USE SP_MEDICAL_GROUP;
GO

INSERT INTO TipoUsuario (tituloTipoUsuario)
VALUES ('Administrador'), ('Médico'), ('Paciente');
GO

INSERT INTO Clinica (nomeClinica, razaoSocial, cnpj, endereco, horarioAbertura, horarioEncerramento) 
VALUES ('Clinica Possarle', 'SP Medical Group', '86400902000130', 'Av. Barão Limeira, 532, São Paulo, SP', '07:00', '18:00' );
GO


INSERT INTO Situacao (descricao)
VALUES ('Realizada'), ('Cancelada'), ('Agendada');
GO

--FEITO ATE AQUI

--INSERT INTO Especialidade (tituloEspecialidade)
--Através de Importação


--INSERT INTO Usuario
--Através de Importação

INSERT INTO Medico(idUsuario, nomeMedico, idEspecialidade, crm)
VALUES (1, 'Ricardo Lemos',2, '54356SP' ), (2, 'Roberto Possarle', 17, '53452SP'), (3, 'Helena Strada', 16, '65463SP');
GO

INSERT INTO Administrador(idUsuario, nomeAdministrador)
VALUES (11, 'Sarah');
GO


--INSERT INTO Paciente
--Através de Importação

--INSERT INTO Consulta
--Através de Importação