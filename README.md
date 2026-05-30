# aspnetcore-clean-architecture-crud
Desafio:
Criar um CRUD de clientes usando Asp.Net Core no padrão MVC na versão mínima .NET
6.0. Abaixo segue a estrutura de tabelas e campos que deverão ser utilizados:

OBS: A entidade “Tipos telefones” será utilizada para cadastrar registros com os
conteúdos: RESIDENCIAL, COMERCIAL, WHATSAPP, etc...
O projeto deverá conter duas camadas de apresentação, Web API e Web App MVC. Fique
à vontade para utilizar outras camadas, como exemplo: Infraestrutura, Negócio,
Domínio, etc.
Requisitos:
✓ A API deverá seguir a arquitetura Restful e poderá ser apresentada através do
Swagger;
✓ Deverá utilizar a linguagem Javascript ou biblioteca JQuery para realizar as
operações com o Controller no MVC;
✓ Para armazenamento dos dados você poderá utilizar um banco de dados de sua
escolha e que seja gratuito;
✓ Utilizar Entity Framework;
Diferencial:
✓ Uso de arquitetura limpa e padrão de repositório;

Segue abaixo os scripts necessários para o Banco de Dados:

# 📦 Database Scripts

## 📋 Criação das Tabelas

### TiposTelefone

```sql
CREATE TABLE TiposTelefone (
    CodigoTipoTelefone    INT           NOT NULL IDENTITY(1,1),
    DescricaoTipoTelefone VARCHAR(100)  NOT NULL,
    DataInsercao          DATETIME      NOT NULL DEFAULT GETDATE(),
    UsuarioInsercao       VARCHAR(100)  NOT NULL,

    CONSTRAINT PK_TiposTelefone PRIMARY KEY (CodigoTipoTelefone)
);
```

---

### Clientes

```sql
CREATE TABLE Clientes (
    CodigoCliente   INT           NOT NULL IDENTITY(1,1),
    RazaoSocial     VARCHAR(200)  NOT NULL,
    NomeFantasia    VARCHAR(200)      NULL,
    TipoPessoa      CHAR(1)       NOT NULL,   -- 'F' Física | 'J' Jurídica
    Documento       VARCHAR(20)   NOT NULL,
    Endereco        VARCHAR(200)      NULL,
    Complemento     VARCHAR(100)      NULL,
    Bairro          VARCHAR(100)      NULL,
    Cidade          VARCHAR(100)      NULL,
    CEP             VARCHAR(9)        NULL,
    UF              CHAR(2)           NULL,
    DataInsercao    DATETIME      NOT NULL DEFAULT GETDATE(),
    UsuarioInsercao VARCHAR(100)  NOT NULL,

    CONSTRAINT PK_Clientes PRIMARY KEY (CodigoCliente)
);
```

---

### Telefones

```sql
CREATE TABLE Telefones (
    CodigoCliente      INT           NOT NULL,
    NumeroTelefone     VARCHAR(20)   NOT NULL,
    CodigoTipoTelefone INT           NOT NULL,
    Operadora          VARCHAR(50)       NULL,
    Ativo              BIT           NOT NULL DEFAULT 1,
    DataInsercao       DATETIME      NOT NULL DEFAULT GETDATE(),
    UsuarioInsercao    VARCHAR(100)  NOT NULL,

    CONSTRAINT PK_Telefones PRIMARY KEY (CodigoCliente, NumeroTelefone),

    CONSTRAINT FK_Telefones_Clientes
        FOREIGN KEY (CodigoCliente)
        REFERENCES Clientes (CodigoCliente),

    CONSTRAINT FK_Telefones_TiposTelefone
        FOREIGN KEY (CodigoTipoTelefone)
        REFERENCES TiposTelefone (CodigoTipoTelefone)
);
```

---

## 🗑️ Remoção das Tabelas

```sql
-- Executar na ordem correta para respeitar as FKs
DROP TABLE IF EXISTS Telefones;
DROP TABLE IF EXISTS Clientes;
DROP TABLE IF EXISTS TiposTelefone;
```

---

## 📊 Índices

```sql
-- Índice para busca de telefones por cliente
CREATE INDEX IX_Telefones_CodigoCliente
    ON Telefones (CodigoCliente);

-- Índice para busca de telefones por tipo
CREATE INDEX IX_Telefones_CodigoTipoTelefone
    ON Telefones (CodigoTipoTelefone);

-- Índice para busca de clientes por documento
CREATE UNIQUE INDEX IX_Clientes_Documento
    ON Clientes (Documento);
```

---

## 🌱 Dados Iniciais (Seed)

```sql
-- Tipos de Telefone
INSERT INTO TiposTelefone (DescricaoTipoTelefone, UsuarioInsercao) VALUES
    ('Celular',     'SISTEMA'),
    ('Fixo',        'SISTEMA'),
    ('Comercial',   'SISTEMA'),
    ('WhatsApp',    'SISTEMA'),
    ('Fax',         'SISTEMA');

-- Cliente de exemplo
INSERT INTO Clientes
    (RazaoSocial, NomeFantasia, TipoPessoa, Documento, Endereco, Complemento, Bairro, Cidade, CEP, UF, UsuarioInsercao)
VALUES
    ('Empresa Teste LTDA', 'Empresa Teste', 'J', '12.345.678/0001-99',
     'Rua das Flores, 123', 'Sala 01', 'Centro', 'Rio das Ostras', '28890-000', 'RJ', 'SISTEMA');

-- Telefone de exemplo
INSERT INTO Telefones
    (CodigoCliente, NumeroTelefone, CodigoTipoTelefone, Operadora, Ativo, UsuarioInsercao)
VALUES
    (1, '22999887766', 1, 'Claro', 1, 'SISTEMA');
```

---

## 🔍 Consultas Úteis

### Listar todos os clientes com seus telefones

```sql
SELECT
    c.CodigoCliente,
    c.RazaoSocial,
    c.NomeFantasia,
    t.NumeroTelefone,
    tt.DescricaoTipoTelefone,
    t.Operadora,
    t.Ativo
FROM Clientes c
LEFT JOIN Telefones t
    ON t.CodigoCliente = c.CodigoCliente
LEFT JOIN TiposTelefone tt
    ON tt.CodigoTipoTelefone = t.CodigoTipoTelefone
ORDER BY c.RazaoSocial, t.NumeroTelefone;
```

### Listar telefones ativos de um cliente

```sql
SELECT
    t.NumeroTelefone,
    tt.DescricaoTipoTelefone,
    t.Operadora
FROM Telefones t
INNER JOIN TiposTelefone tt
    ON tt.CodigoTipoTelefone = t.CodigoTipoTelefone
WHERE t.CodigoCliente = 1
  AND t.Ativo = 1;
```

### Buscar cliente por documento

```sql
SELECT *
FROM Clientes
WHERE Documento = '12.345.678/0001-99';
```

Abaixo temos algumas telas do sistema em funcionamento:
Tela LISTA CLIENTES:

<img width="1344" height="414" alt="image" src="https://github.com/user-attachments/assets/8607c49c-fa63-47f9-82b9-444296ab22fb" />

Tela DETALHE CLIENTE:

<img width="1329" height="687" alt="image" src="https://github.com/user-attachments/assets/635bf188-c492-463d-b6a9-d7ab35d31259" />

Tela NOVO CLIENTE

<img width="1321" height="819" alt="image" src="https://github.com/user-attachments/assets/d4af2752-a8c8-4c02-9633-a39b43fb2d2a" />

Tela EDIT CLIENTE

<img width="1321" height="810" alt="image" src="https://github.com/user-attachments/assets/493a70c5-5ebb-4a82-b306-cf9a3b8c6e90" />


