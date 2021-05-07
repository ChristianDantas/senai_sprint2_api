USE MedGroup;

INSERT INTO Clinicas(RazaoSocial,Endereco, CNPJ, NomeFantasia, HorarioFuncionamento )
values               ('SP Medical Group','AV. Barão Limeira,532','86.400.902/0001-30','Clinica Porssale', '6:00-23:00');
GO



INSERT INTO Especialidades(Especialidade )
values               ('Aculpuntura')
					,('Anestesiologia')
					,('Angiologia')
					,('Cardiologia')
					,('Cirurgia Cardiovascular')
					,('Cirurgia de Mão')
					,('Cirurgia do Aparelho Digestivo')
					,('Cirurgia Geral')
					,('Cirurgia Pediátrica')
					,('Cirurgia Plástica')
					,('Cirurgia Torácica')
					,('Cirurgia Vascular')
					,('Dermatologia')
					,('Radioterapia')
					,('Urologia')
					,('Pediatria')
					,('Psiquiatria');


INSERT INTO TipoUsuarios(TituloUsuario)
VALUES               ('Administrador')
					,('Paciente')
					,('Medico');

INSERT INTO Usuarios(Senha,Email,IdTipoU)
VALUES              ('Ricardo123','ricardo.lemos@spmedicalgroup.com',3)
					,('Porssale456','roberto.porssale@spmedicalgroup.com',3)
					,('Helena789','helena.souza@spmedicalgroup.com', 3)
					,('Ligia123','ligia@gmail.com',2)
					,('Alexandre456','alexandre@gmail.com',2)
					,('Fernando789','fernando@gmail.com', 2)
					,('Henrique987','henrique@gmail.com', 2)
					,('Joao654','joao@gmail.com', 2)
					,('Bruno321','Bruno@gmail.com', 2)
					,('Mariana987','Mariana@gmail.com', 2)
					,('Adm123','adm@adm.com', 1);

INSERT INTO Situacao(Situacao)
VALUES              ('Realizada')
					,('Cancelada')
					,('Agendada');

INSERT INTO Pacientes(NomePaciente,IdUsuario,RG,CPF,Telefone,endereco,DataNascimento)
values               ('Ligia',4,'43522543-5','94839859000','11 3456-7654','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000','03/10/1983')
					,('Alexandre',5,'32654345-7','73556944057','11 98765-6543','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200','03/07/2001')
					,('Fernando',6,'54636525-3','16839338002','11 97208-4453','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200','10/10/1978')
					,('Henrique',7,'54366362-5','14332654765','11 3456-6543','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030','13/10/1985')
					,('João',8,'t32544444-1','91305348010','11 7656-6377','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380','27/08/1975')
					,('Bruno',9,'54566266-7','79799299004','11 95436-8769','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001','21/03/1972')
					,('Mariana',10,'54566266-8','13771913039','','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140','05/03/2018');

INSERT INTO Medicos(IdUsuario,IdEspecialidade,IdClinica,NomeMedico,CRV)
VALUES              (1,1,1,'Ricardo Lemos','54356-SP')
					,(2,17,1,'Roberto Porssale','53452-SP')
					,(3,16,1,'Helena Souza','65463-SP');

INSERT INTO Medicos(IdUsuario,IdEspecialidade,IdClinica,NomeMedico,CRV)
VALUES              (1,1,1,'Ricardo Lemos','54356-SP')
					,(2,17,1,'Roberto Porssale','53452-SP')
					,(3,16,1,'Helena Souza','65463-SP');

INSERT INTO Consultas(IdMedico,IdPaciente,IdSituacao,DescricaoConsulta,DataConsulta)
VALUES              (3,7,1,'Criança com catarro na garganta','14/04/2021')
					,(2,2,2,'Paciente com falta de confiança em si mesmo','28/03/2021')
					,(2,3,1,'Paciente com depressão severa','29/03/2021')
					,(2,2,1,'Paciente com boderline','08/04/21')
					,(1,4,2,'Paciente verificando se tem alergia a anestesia utilizada na cirurgia','21/05/2021')
					,(3,7,3,'Criança com dor de bronquilote','30/03/2021')
					,(1,4,3,'Paciente com parestesia','06/04/21');