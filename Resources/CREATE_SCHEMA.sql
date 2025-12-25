-- ==========================================
-- PostgreSQL 17 用 初期化SQL（cs_db_exercise）
-- ==========================================

-- 事前に接続先DBを cs_db_exercise にしておく
-- psqlの場合: \c cs_db_exercise

-- 依存関係を考慮して削除（FKがある側→参照先の順にDROP）
DROP TABLE IF EXISTS sales_detail;
DROP TABLE IF EXISTS sales;
DROP TABLE IF EXISTS item_stock;
DROP TABLE IF EXISTS employee;
DROP TABLE IF EXISTS department;
DROP TABLE IF EXISTS account;
DROP TABLE IF EXISTS account_role;
DROP TABLE IF EXISTS item;
DROP TABLE IF EXISTS item_category;

-- ============================
-- アカウント権限 account_role
-- ============================
CREATE TABLE account_role
(
  role_id   integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  role_name varchar(20),
  CONSTRAINT account_role_pk PRIMARY KEY (role_id)
);

INSERT INTO account_role (role_name) VALUES ('ADMIN');
INSERT INTO account_role (role_name) VALUES ('USER');
INSERT INTO account_role (role_name) VALUES ('GUEST');

-- ============================
-- アカウント account
-- ============================
CREATE TABLE account
(
  user_id      integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  user_name    varchar(20),
  password     varchar(100),
  display_name varchar(20),
  enabled      boolean, -- true/false
  role_id      integer,
  CONSTRAINT account_pk PRIMARY KEY (user_id),
  CONSTRAINT account_role_fk FOREIGN KEY (role_id)
      REFERENCES account_role (role_id)
);

INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('YAMADA','pass1','山田太郎',true,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('SUZUKI','pass2','鈴木花子',true,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('TANAKA','pass3','田中二郎',true,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('YAMAMOTO','pass4','山本涼子',true,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('STOU','pass5','佐藤光一',true,2);
INSERT INTO account (user_name, password, display_name, enabled, role_id) VALUES ('PEKIN','pass100','ゼンジー北京',true,2);

-- ============================
-- 商品カテゴリ item_category
-- ============================
CREATE TABLE item_category
(
  id   integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  name varchar(20),
  CONSTRAINT item_category_pk PRIMARY KEY (id)
);

INSERT INTO item_category (name) VALUES ('文房具');
INSERT INTO item_category (name) VALUES ('雑貨');
INSERT INTO item_category (name) VALUES ('パソコン周辺機器');

-- ============================
-- 商品 item
-- ============================
CREATE TABLE item
(
  id          integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  name        varchar(30),
  price       integer,
  category_id integer,
  CONSTRAINT item_pk PRIMARY KEY (id),
  CONSTRAINT item_category_fk FOREIGN KEY (category_id)
      REFERENCES item_category (id)
);

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
  id      integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  stock   integer,
  item_id integer,
  CONSTRAINT item_stock_pk PRIMARY KEY (id),
  CONSTRAINT item_fk FOREIGN KEY (item_id)
      REFERENCES item (id)
);

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
  id         integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  sales_date date,
  total      integer,
  account_id integer,
  CONSTRAINT sales_pk PRIMARY KEY (id),
  CONSTRAINT account_fk FOREIGN KEY (account_id)
      REFERENCES account (user_id)
);

-- ============================
-- 売上明細 sales_detail
-- ============================
CREATE TABLE sales_detail
(
  id        integer GENERATED ALWAYS AS IDENTITY NOT NULL,
  sales_id  integer NOT NULL,
  quantity  integer,
  subtotal  integer,
  item_id   integer,
  CONSTRAINT sales_detail_pk PRIMARY KEY (id),
  CONSTRAINT sales_detail_item_fk FOREIGN KEY (item_id)
      REFERENCES item (id),
  CONSTRAINT sales_fk FOREIGN KEY (sales_id)
      REFERENCES sales (id)
);

-- 売上データ + 明細データ
INSERT INTO sales (sales_date, total, account_id) VALUES ('2020-05-01',240,1);
INSERT INTO sales_detail (sales_id, quantity, subtotal, item_id) VALUES (1,2,240,1);

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
-- 部門 department
-- ============================
CREATE TABLE department
(
  id   integer GENERATED ALWAYS AS IDENTITY,
  name varchar(20) NOT NULL,
  CONSTRAINT pk_dept_id PRIMARY KEY (id),
  CONSTRAINT nn_dept_name CHECK (name <> '')
);

INSERT INTO department (name) VALUES ('総務部');
INSERT INTO department (name) VALUES ('経理部');
INSERT INTO department (name) VALUES ('人事部');
INSERT INTO department (name) VALUES ('開発部');
INSERT INTO department (name) VALUES ('営業部');

-- ============================
-- 社員 employee
-- ============================
CREATE TABLE employee
(
  id      integer GENERATED ALWAYS AS IDENTITY,
  name    varchar(20) NOT NULL,
  dept_id integer,
  CONSTRAINT pk_emp_no PRIMARY KEY (id),
  CONSTRAINT fk_dept_no FOREIGN KEY (dept_id)
      REFERENCES department(id)
);

INSERT INTO employee (name, dept_id) VALUES ('田中太郎',2);
INSERT INTO employee (name, dept_id) VALUES ('鈴木三郎',1);
INSERT INTO employee (name, dept_id) VALUES ('佐藤花子',4);
INSERT INTO employee (name, dept_id) VALUES ('中田彩子',5);
INSERT INTO employee (name, dept_id) VALUES ('加藤圭太',3);
INSERT INTO employee (name, dept_id) VALUES ('松本良太',4);
INSERT INTO employee (name, dept_id) VALUES ('山下孝輔',5);
INSERT INTO employee (name, dept_id) VALUES ('渡辺大輔',4);