-- 作業するデータベースを選択（事前に CREATE DATABASE cs_db_exercise しておく）
USE cs_db_exercise;

-- 外部キー制約を気にせず削除するため一時的に無効化
SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS sales_detail; 
DROP TABLE IF EXISTS sales; 
DROP TABLE IF EXISTS item_stock; 
DROP TABLE IF EXISTS account; 
DROP TABLE IF EXISTS account_role; 
DROP TABLE IF EXISTS item;
DROP TABLE IF EXISTS item_category;
DROP TABLE IF EXISTS EMPLOYEE;
DROP TABLE IF EXISTS DEPARTMENT;

SET FOREIGN_KEY_CHECKS = 1;

-- ============================
-- アカウント権限 account_role
-- ============================
CREATE TABLE account_role
(
  role_id   INT AUTO_INCREMENT NOT NULL,
  role_name VARCHAR(20),
  CONSTRAINT account_role_pk PRIMARY KEY (role_id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO account_role (role_name) VALUES ('ADMIN');
INSERT INTO account_role (role_name) VALUES ('USER');
INSERT INTO account_role (role_name) VALUES ('GUEST');

-- ============================
-- アカウント account
-- ============================
CREATE TABLE account
(
  user_id      INT AUTO_INCREMENT NOT NULL,
  user_name    VARCHAR(20),
  password     VARCHAR(100),
  display_name VARCHAR(20),
  enabled      TINYINT(1), -- 1: TRUE, 0: FALSE
  role_id      INT,
  CONSTRAINT account_pk PRIMARY KEY (user_id),
  CONSTRAINT account_role_fk FOREIGN KEY (role_id)
      REFERENCES account_role (role_id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('YAMADA','pass1','山田太郎',1,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('SUZUKI','pass2','鈴木花子',1,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('TANAKA','pass3','田中二郎',1,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('YAMAMOTO','pass4','山本涼子',1,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('STOU','pass5','佐藤光一',1,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('PEKIN','pass100','ゼンジー北京',1,2);

-- ============================
-- 商品カテゴリ item_category
-- ============================
CREATE TABLE item_category
(
  id   INT AUTO_INCREMENT NOT NULL,
  name VARCHAR(20),
  CONSTRAINT item_category_pk PRIMARY KEY (id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO item_category (name) VALUES ('文房具');
INSERT INTO item_category (name) VALUES ('雑貨');
INSERT INTO item_category (name) VALUES ('パソコン周辺機器');

-- ============================
-- 商品 item
-- ============================
CREATE TABLE item
(
  id          INT AUTO_INCREMENT NOT NULL,
  name        VARCHAR(30),
  price       INT,
  category_id INT,
  CONSTRAINT item_pk PRIMARY KEY (id),
  CONSTRAINT item_category_fk FOREIGN KEY (category_id)
      REFERENCES item_category (id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO item (name, price, category_id) VALUES ('水性ボールペン(黒)',120,1);
INSERT INTO item (name, price, category_id) VALUES ('水性ボールペン(赤)',120,1);
INSERT INTO item (name, price, category_id) VALUES ('水性ボールペン(青)',120,1);
INSERT INTO item (name, price, category_id) VALUES ('油性ボールペン(黒)',100,1);
INSERT INTO item (name, price, category_id) VALUES ('油性ボールペン(赤)',100,1);
INSERT INTO item (name, price, category_id) VALUES ('油性ボールペン(青)',100,1);
INSERT INTO item (name, price, category_id) VALUES ('蛍光ペン(黄)',130,1);
INSERT INTO item (name, price, category_id) VALUES ('蛍光ペン(赤)',130,1);
INSERT INTO item (name, price, category_id) VALUES ('蛍光ペン(青)',130,1);
INSERT INTO item (name, price, category_id) VALUES ('蛍光ペン(緑)',130,1);
INSERT INTO item (name, price, category_id) VALUES ('鉛筆(黒)',100,1);
INSERT INTO item (name, price, category_id) VALUES ('鉛筆(赤)',100,1);
INSERT INTO item (name, price, category_id) VALUES ('色鉛筆(12色)',400,1);
INSERT INTO item (name, price, category_id) VALUES ('色鉛筆(48色)',1300,1);
INSERT INTO item (name, price, category_id) VALUES ('レザーネックレス',300,2);
INSERT INTO item (name, price, category_id) VALUES ('ワンタッチ開閉傘',3000,2);
INSERT INTO item (name, price, category_id) VALUES ('金魚風呂敷',500,2);
INSERT INTO item (name, price, category_id) VALUES ('折畳トートバッグ',600,2);
INSERT INTO item (name, price, category_id) VALUES ('アイマスク',900,2);
INSERT INTO item (name, price, category_id) VALUES ('防水スプレー',500,2);
INSERT INTO item (name, price, category_id) VALUES ('キーホルダ',800,2);
INSERT INTO item (name, price, category_id) VALUES ('ワイヤレスマウス',900,3);
INSERT INTO item (name, price, category_id) VALUES ('ワイヤレストラックボール',1300,3);
INSERT INTO item (name, price, category_id) VALUES ('有線光学式マウス',500,3);
INSERT INTO item (name, price, category_id) VALUES ('光学式ゲーミングマウス',4800,3);
INSERT INTO item (name, price, category_id) VALUES ('有線ゲーミングマウス',3800,3);
INSERT INTO item (name, price, category_id) VALUES ('USB有線式キーボード',1400,3);
INSERT INTO item (name, price, category_id) VALUES ('無線式キーボード',1900,3);

-- ============================
-- 商品在庫 item_stock
-- ============================
CREATE TABLE item_stock
(
  id      INT AUTO_INCREMENT NOT NULL,
  stock   INT,
  item_id INT,
  CONSTRAINT item_stock_pk PRIMARY KEY (id),
  CONSTRAINT item_fk FOREIGN KEY (item_id)
      REFERENCES item (id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO item_stock (stock, item_id) VALUES (20,1);
INSERT INTO item_stock (stock, item_id) VALUES (20,2);
INSERT INTO item_stock (stock, item_id) VALUES (20,3);
INSERT INTO item_stock (stock, item_id) VALUES (20,4);
INSERT INTO item_stock (stock, item_id) VALUES (10,5);
INSERT INTO item_stock (stock, item_id) VALUES (10,6);
INSERT INTO item_stock (stock, item_id) VALUES (20,7);
INSERT INTO item_stock (stock, item_id) VALUES (15,8);
INSERT INTO item_stock (stock, item_id) VALUES (13,9);
INSERT INTO item_stock (stock, item_id) VALUES (15,10);
INSERT INTO item_stock (stock, item_id) VALUES (20,11);
INSERT INTO item_stock (stock, item_id) VALUES (15,12);
INSERT INTO item_stock (stock, item_id) VALUES (15,13);
INSERT INTO item_stock (stock, item_id) VALUES (20,14);
INSERT INTO item_stock (stock, item_id) VALUES (10,15);
INSERT INTO item_stock (stock, item_id) VALUES (10,16);
INSERT INTO item_stock (stock, item_id) VALUES (20,17);
INSERT INTO item_stock (stock, item_id) VALUES (30,18);
INSERT INTO item_stock (stock, item_id) VALUES (40,19);
INSERT INTO item_stock (stock, item_id) VALUES (20,20);
INSERT INTO item_stock (stock, item_id) VALUES (10,21);
INSERT INTO item_stock (stock, item_id) VALUES (12,22);
INSERT INTO item_stock (stock, item_id) VALUES (11,23);
INSERT INTO item_stock (stock, item_id) VALUES (5,24);
INSERT INTO item_stock (stock, item_id) VALUES (5,25);
INSERT INTO item_stock (stock, item_id) VALUES (5,26);
INSERT INTO item_stock (stock, item_id) VALUES (5,27);
INSERT INTO item_stock (stock, item_id) VALUES (5,28);

-- ============================
-- 売上 sales
-- ============================
CREATE TABLE sales
(
  id         INT AUTO_INCREMENT NOT NULL,
  sales_date DATE,
  total      INT,
  account_id INT,
  CONSTRAINT sales_pk PRIMARY KEY (id),
  CONSTRAINT account_fk FOREIGN KEY (account_id)
      REFERENCES account (user_id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

-- ============================
-- 売上明細 sales_detail
-- ============================
CREATE TABLE sales_detail
(
  id        INT AUTO_INCREMENT NOT NULL,
  sales_id  INT NOT NULL,
  quantity  INT,
  subtotal  INT,
  item_id   INT,
  CONSTRAINT sales_detail_pk PRIMARY KEY (id, sales_id),
  CONSTRAINT sales_detail_item_fk FOREIGN KEY (item_id)
      REFERENCES item (id),
  CONSTRAINT sales_fk FOREIGN KEY (sales_id)
      REFERENCES sales (id)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

-- 売上データ + 明細データ
INSERT INTO sales (sales_date, total, account_id) VALUES ('2020-05-01',240,1);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (1,2,240,1); -- 120x2 のイメージなど

INSERT INTO sales (sales_date, total, account_id) VALUES ('2020-05-05',300,2);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (2,1,100,4);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (2,1,100,5);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (2,1,100,6);

INSERT INTO sales (sales_date, total, account_id) VALUES ('2020-05-06',1400,4);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (3,1,1400,28);

INSERT INTO sales (sales_date, total, account_id) VALUES ('2020-05-07',3500,3);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (4,1,3000,16);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (4,1,500,17);

-- ============================
-- 部門 DEPARTMENT
-- ============================
CREATE TABLE DEPARTMENT
(
  DEPT_NO   INT AUTO_INCREMENT,
  DEPT_NAME VARCHAR(20) NOT NULL,
  CONSTRAINT PK_DEPT_NO PRIMARY KEY (DEPT_NO),
  CONSTRAINT NN_DEPT_NAME CHECK (DEPT_NAME <> '')
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

INSERT INTO DEPARTMENT (DEPT_NAME) VALUES ('総務部');
INSERT INTO DEPARTMENT (DEPT_NAME) VALUES ('経理部');
INSERT INTO DEPARTMENT (DEPT_NAME) VALUES ('人事部');
INSERT INTO DEPARTMENT (DEPT_NAME) VALUES ('開発部');
INSERT INTO DEPARTMENT (DEPT_NAME) VALUES ('営業部');

-- ============================
-- 社員 EMPLOYEE
-- ============================
CREATE TABLE EMPLOYEE
(
  EMP_NO  INT AUTO_INCREMENT,
  NAME    VARCHAR(20) NOT NULL,
  DEPT_NO INT,
  CONSTRAINT PK_EMP_NO PRIMARY KEY (EMP_NO),
  CONSTRAINT FK_DEPT_NO FOREIGN KEY (DEPT_NO)
      REFERENCES DEPARTMENT(DEPT_NO)
) ENGINE=InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_0900_ai_ci;

-- 元SQLは DEPT_ID になっていたが、カラム名は DEPT_NO なので修正
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('田中太郎',102);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('鈴木三郎',101);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('佐藤花子',104);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('中田彩子',105);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('加藤圭太',103);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('松本良太',104);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('山下孝輔',105);
INSERT INTO EMPLOYEE (NAME, DEPT_NO) VALUES ('渡辺大輔',104);
