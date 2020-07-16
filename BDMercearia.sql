Create database BDMercearia;

Use BDMercearia;

Create table Login (
login varchar (20),
senha varchar (25),
primary key (login));

Insert into Login values
('admin','123');

Create table Produtos (
CodigoProduto int not null,
NomeProduto varchar(50),
Preco double,
primary key (CodigoProduto));

Create table Vendas (
CodigoVenda int not null,
PreçoTotal double,
FormaPagamento varchar(20),
DataVenda varchar(10),
primary key (CodigoVenda));

Create table Venda_Detalhes (
CodigoVenda int not null,
CodigoProduto int not null,
Quantidade int not null,
foreign key (CodigoVenda) references Vendas (CodigoVenda),
foreign key (CodigoProduto) references Produtos (CodigoProduto));