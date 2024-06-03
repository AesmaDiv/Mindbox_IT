import sqlite3

# скрипт инициализации БД
SQL_INIT_DATABASE = """
DROP TABLE IF EXISTS Products;
CREATE TABLE Products (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL
);
DROP TABLE IF EXISTS Categories;
CREATE TABLE Categories (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL
);
DROP TABLE IF EXISTS Product_Category;
CREATE TABLE Product_Category (
    id_product INTEGER,
    id_category INTEGER,
    FOREIGN KEY (id_product) REFERENCES Products(id),
    FOREIGN KEY (id_category) REFERENCES Categories(id)
);
"""
# собственно запрос, который требовалось сформировать
SQL_SELECT = """
SELECT p.name AS 'Продукт', c.name AS 'Категория'
FROM Products AS p
LEFT JOIN Product_Category AS pc ON p.id = pc.id_product
LEFT JOIN Categories AS c ON c.id = pc.id_category;
"""

# наполнение таблиц
products = [(1, 'Ботинки'),(2, 'Туфли'),(3, 'Зонт'),(4, 'Пиджак')]
categories = [(1, 'Мужское'),(2, 'Женское'),(3, 'Зимнее'),(4, 'Летнее')]
product_category = [(1,1),(1,3),(2,2),(2,4),(4,1)]

if __name__ == "__main__":
    con = sqlite3.connect("db.sqlite")
    # ресетим БД
    cur = con.executescript(SQL_INIT_DATABASE)
    # заполняем таблицы
    con.executemany("INSERT INTO Products (id, name) Values (?, ?)", products)
    con.executemany("INSERT INTO Categories (id, name) Values (?, ?)", categories)
    con.executemany("INSERT INTO Product_Category (id_product, id_category) Values (?, ?)", product_category)
    # выполняем тот-самый запрос
    cur = con.execute(SQL_SELECT)
    result = cur.fetchall()
    # отключаемся от БД
    cur.close()
    con.close()
    # выводим результат запроса в консоль
    for row in result:
        print(row)
    # PROFIT!!!