--Criando Banco de Dados Almoxarifa
CREATE DATABASE db_almoxarifadoAPI

USE db_almoxarifadoAPI

--Criando Tabelas

--Criando Tabela Fornecedores
--Dados dos fornecedores dos itens
--Completo
CREATE TABLE Fornecedores(
id_fornecedor INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(90) NOT NULL,
descricao VARCHAR(500)
);

--Criando Tabela Categorias
--Categorias de itens e itens dos fornecedores
--Completo
CREATE TABLE Categorias(
id_categoria INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(90) NOT NULL,
descricao VARCHAR(400)
);

--Criando Tabelas Fornecedores_Categorias
--Completo
CREATE TABLE Fornecedores_Categorias(
id_fornecedor INT NOT NULL,
id_categoria INT NOT NULL,
FOREIGN KEY(id_fornecedor) REFERENCES Fornecedores(id_fornecedor),
FOREIGN KEY(id_categoria) REFERENCES Categorias(id_categoria)
);

--Criando Tabela Enderecos_Fornecedor
--Completa
CREATE TABLE Enderecos_Fornecedor(
id_endereco INT PRIMARY KEY IDENTITY(1,1),
logadouro VARCHAR(100) NOT NULL,
bairro VARCHAR(100) NOT NULL,
numero VARCHAR(20) NOT NULL,
complemento VARCHAR(100),
cidade VARCHAR(100) NOT NULL,
estado VARCHAR(100) NOT NULL,
pais VARCHAR(100) NOT NULL,
id_fornecedor INT NOT NULL,
FOREIGN KEY(id_fornecedor) REFERENCES Fornecedores(id_fornecedor)
);

--Criando Tabela Telefones_Fornecedor
--Completa
CREATE TABLE Telefones_Fornecedor(
id_telefone INT PRIMARY KEY IDENTITY(1,1),
telefone VARCHAR(20) NOT NULL,
id_fornecedor INT NOT NULL,
FOREIGN KEY(id_fornecedor) REFERENCES Fornecedores(id_fornecedor)
);

--Criando Tabela Emails_Fornecedor
--Completa
CREATE TABLE Emails_Fornecedor(
id_email INT PRIMARY KEY IDENTITY(1,1),
email VARCHAR(70) NOT NULL,
id_fornecedor INT NOT NULL,
FOREIGN KEY(id_fornecedor) REFERENCES Fornecedores(id_fornecedor)
);

--Criando Tabela Itens
--Completa
CREATE TABLE Itens(
id_item INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(90) NOT NULL,
descricao VARCHAR(500)
);

--Criando Tabela Categorias_Item
--Completa
CREATE TABLE Itens_Categorias(
id_item INT NOT NULL,
id_categoria INT NOT NULL,
FOREIGN KEY(id_item) REFERENCES Itens(id_item),
FOREIGN KEY(id_categoria) REFERENCES  Categorias(id_categoria)
);

--Criando Tabela Departamentos
--Completa
CREATE TABLE Departamentos(
id_departamento INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100) NOT NULL,
);

--Criando Tabela Funcionarios
--Completa
CREATE TABLE Funcionarios (
id_funcionario INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(100) NOT NULL,
cargo VARCHAR(50) NOT NULL,
id_departamento INT NOT NULL,
FOREIGN KEY (id_departamento) REFERENCES Departamentos(id_departamento)
);

--Completa
CREATE TABLE Telefones_Funcionario(
id_telefone INT PRIMARY KEY IDENTITY(1,1),
telefone VARCHAR(20) NOT NULL,
id_funcionario INT NOT NULL,
FOREIGN KEY(id_funcionario) REFERENCES Funcionarios(id_funcionario)
);

--Completa
CREATE TABLE Emails_Funcionario(
id_email INT PRIMARY KEY IDENTITY(1,1),
email VARCHAR(70) NOT NULL,
id_funcionario INT NOT NULL,
FOREIGN KEY(id_funcionario) REFERENCES Funcionarios(id_funcionario)
);

--Criando Tabela Entradas
--Dados das transações de entrada e saída,
--podendo estar a associada a nenhuma ou
--várias entradas/saídas
--Completa
CREATE TABLE Transacoes(
id_transacao INT PRIMARY KEY IDENTITY(1,1),
data_transacao DATE NOT NULL,
tipo VARCHAR(20) NOT NULL,
motivo VARCHAR(100) NOT NULL,
id_funcionario INT NOT NULL,
FOREIGN KEY(id_funcionario) REFERENCES Funcionarios(id_funcionario),
CONSTRAINT chk_tipo CHECK(tipo IN('entrada', 'saida'))
);

--Criando Tabela Entradas
--Dados de entrada de lotes podendo estar associada a nenhum ou vários lotes
--Completa
CREATE TABLE Entradas(
id_entrada INT PRIMARY KEY IDENTITY(1,1),
data_entrada DATE NOT NULL,
condicao VARCHAR(100) NOT NULL,
nota VARCHAR(300),
id_transacao INT NOT NULL,
id_funcionario INT NOT NULL,
FOREIGN KEY(id_transacao) REFERENCES Transacoes(id_transacao),
FOREIGN KEY(id_funcionario) REFERENCES Funcionarios(id_funcionario)
);

--Criando Tabela Lotes
--Dados dos lotes que formam o estoque
--Completa
CREATE TABLE Lotes(
id_lote INT PRIMARY KEY IDENTITY(1,1),
preco_unitario DECIMAL(10,2) NOT NULL,
quantidade_entrada INT NOT NULL,
quantidade_atual INT NOT NULL,
data_validade DATE,
localizacao VARCHAR(90) NOT NULL,
id_entrada INT NOT NULL,
id_item INT NOT NULL,
id_fornecedor INT NOT NULL,
FOREIGN KEY(id_entrada) REFERENCES Entradas(id_entrada),
FOREIGN KEY(id_item) REFERENCES Itens(id_item),
FOREIGN KEY(id_fornecedor) REFERENCES Fornecedores(id_fornecedor)
);

--Criando Tabela Saidas
--Dados da saída de itens de um lote
--Completa
CREATE TABLE Saidas(
id_saida INT PRIMARY KEY IDENTITY(1,1),
data_saida DATE NOT NULL,
condicao VARCHAR(100) NOT NULL,
quantidade_saida INT NOT NULL,
nota VARCHAR(300),
id_transacao INT NOT NULL,
id_lote INT NOT NULL,
id_funcionario_responsavel INT NOT NULL,
id_funcionario_receptor INT NOT NULL,
FOREIGN KEY(id_transacao) REFERENCES Transacoes(id_transacao),
FOREIGN KEY(id_lote) REFERENCES Lotes(id_lote),
FOREIGN KEY(id_funcionario_responsavel) REFERENCES Funcionarios(id_funcionario),
FOREIGN KEY(id_funcionario_receptor) REFERENCES Funcionarios(id_funcionario)
);