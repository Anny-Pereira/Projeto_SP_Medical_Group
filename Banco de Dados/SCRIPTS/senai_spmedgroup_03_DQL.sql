USE SP_MEDICAL_GROUP;
GO

SELECT * FROM TipoUsuario;
GO

SELECT * FROM Clinica;
GO

SELECT * FROM Situacao;
GO

SELECT * FROM Especialidade;
GO

SELECT * FROM Usuario;
GO

SELECT * FROM Medico;
GO

SELECT * FROM Administrador;
GO

SELECT * FROM Paciente;
GO

SELECT * FROM Consulta;
GO

SELECT Paciente.nomePaciente AS [Nome do Paciente], Medico.nomeMedico AS [Nome do M�dico], Situacao.descricao AS [Situa��o], dataConsulta AS [Data da Consulta], Consulta.descricao AS [Descri��o da Consulta]
FROM Consulta
INNER JOIN Paciente ON Consulta.idPaciente = Paciente.idPaciente
INNER JOIN Medico ON  Consulta.idMedico = Medico.idMedico
INNER JOIN Situacao ON Consulta.idSituacao = Situacao.idSituacao;
GO

--Consultas de um paciente
SELECT Paciente.nomePaciente AS [Nome do Paciente], Situacao.descricao AS [Situa��o], dataConsulta AS [Data da Consulta]
FROM Consulta
INNER JOIN Paciente ON Consulta.idPaciente = Paciente.idPaciente
INNER JOIN Situacao ON Consulta.idSituacao = Situacao.idSituacao
WHERE Consulta.idPaciente = 7;
GO


--Consultas de um m�dico
SELECT Medico.nomeMedico AS [Nome do M�dico] , Situacao.descricao AS [Situa��o], dataConsulta AS [Data da Consulta]
FROM Consulta
INNER JOIN Medico ON  Consulta.idMedico = Medico.idMedico
INNER JOIN Situacao ON Consulta.idSituacao = Situacao.idSituacao
WHERE Consulta.idMedico = 2;
GO

--Login
SELECT  TipoUsuario.tituloTipoUsuario, Usuario.email, Usuario.senha FROM Usuario
INNER JOIN TipoUsuario ON Usuario.idTipoUsuario = TipoUsuario.idTipoUsuario
WHERE email = 'ligia@gmail.com'
AND senha = '444';
GO


--PROBLEMA!
--Mostra a quantidade de usu�rios 
SELECT COUNT (idUsuario) AS [ID do usu�rio]
FROM Usuario;
GO


--Stored Procedure que retorna a quantidade de m�dicos de uma determinada especialidade
CREATE PROCEDURE P_MedicosEspecialidade (@idEspecialidade SMALLINT)
AS 
BEGIN
SELECT nomeMedico AS [Nome do M�dico],tituloEspecialidade AS [Especialidade]
FROM Medico
INNER JOIN Especialidade
ON Medico.idEspecialidade = Especialidade.idEspecialidade
WHERE Especialidade.idEspecialidade = 2
END

EXEC P_MedicosEspecialidade @idEspecialidade = 2;
GO