USE cadastro_veiculos;

-- apaga os veículos existentes e reinicia os IDs
DELETE FROM Veiculos;
ALTER TABLE Veiculos AUTO_INCREMENT = 1;

INSERT INTO Veiculos (Placa, Marca, Modelo, Cor, Ano, Porte, TipoCarga, Chassis) VALUES
    ('ABC1D23', 'Volvo',         'FH 540',               'Branco',   2022, 'Grande',  'Granel',        '9BWZZZ377VT004251'),
    ('BRA2E19', 'Mercedes-Benz', 'Accelo 1016',          'Prata',    2020, 'Medio',   'Carga Seca',    '9BGRD08X04G117974'),
    ('XYZ9876', 'Fiat',          'Fiorino',              'Vermelho', 2018, 'Pequeno', 'Carga Seca',    '9BD15802786123456'),
    ('FJK4H56', 'Scania',        'R 450',                'Azul',     2023, 'Grande',  'Frigorificada', '9BM384067BB123456'),
    ('GHT3B45', 'Volkswagen',    'Delivery 11.180',      'Branco',   2021, 'Medio',   'Baú',           '9BVR6AE25ME123789'),
    ('KLM7890', 'Iveco',         'Daily 35-150',         'Cinza',    2019, 'Pequeno', 'Carga Seca',    '9BSR6X200H3987654'),
    ('RST5C12', 'DAF',           'XF 530',               'Preto',    2024, 'Grande',  'Contêiner',     '93ZA1RFH0K8456123'),
    ('DEF2345', 'Ford',          'Cargo 2429',           'Branco',   2017, 'Grande',  'Basculante',    '9BFZB55P5J8765432'),
    ('MNP8F67', 'Renault',       'Master',               'Prata',    2022, 'Pequeno', 'Refrigerada',   '93HFC1650MZ246810'),
    ('QWE6G01', 'Volkswagen',    'Constellation 24.280', 'Amarelo',  2020, 'Grande',  'Tanque',        '9BWAA05U2EP135792');
