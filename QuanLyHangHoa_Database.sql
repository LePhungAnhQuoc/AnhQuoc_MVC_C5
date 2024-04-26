create database [QuanLyHangHoa]
GO
Use [QuanLyHangHoa]
GO

CREATE TABLE Categories (
	Id int IDENTITY(1,1) primary key,
	Name nvarchar(50) NOT NULL 
)
-- ----------------------------
-- Records of Categories
-- ----------------------------
INSERT INTO Categories (Name) VALUES (N'Sách');
INSERT INTO Categories (Name) VALUES (N'Điện thoại');
INSERT INTO Categories (Name) VALUES (N'Máy chụp hình');
INSERT INTO Categories (Name) VALUES (N'Quần áo - Giày dép');
INSERT INTO Categories (Name) VALUES (N'Máy tính');
INSERT INTO Categories (Name) VALUES (N'Đồ trang sức');
INSERT INTO Categories (Name) VALUES (N'Khác');

-- ----------------------------
-- Table structure for [dbo].[Users]
-- ----------------------------

CREATE TABLE Users (
	Id int IDENTITY(1,1) primary key,
	Username varchar(50) NOT NULL ,
	Password varchar(255) NOT NULL ,
	Name varchar(50) NOT NULL ,
	Email varchar(50) NOT NULL ,
	DOB datetime NOT NULL ,
	Permission int NOT NULL DEFAULT 0 
)

-- ----------------------------
-- Records of Users
-- ----------------------------

INSERT INTO Users (Username, Password, Name, Email, DOB, Permission) VALUES (N'dark', N'123', N'Tran', N'dark@a.c', N'2014-02-26 00:00:00.000', 0);
INSERT INTO Users (Username, Password, Name, Email, DOB, Permission) VALUES (N'hoai', N'123', N'Admin', N'admin@g.c', N'2014-03-19 00:00:00.000', 1);

-- ----------------------------
-- Table structure for [dbo].[Products]
-- ----------------------------
CREATE TABLE Products (
	Id int IDENTITY(1,1) primary key,
	Name varchar(40) NOT NULL ,
	TinyDes varchar(80) NOT NULL ,
	FullDes text NOT NULL ,
	Price float NOT NULL ,
	CatID int NOT NULL ,
	Quantity int NOT NULL DEFAULT 0
	
	foreign key (CatID) references Categories(Id),
)
-- ----------------------------
-- Records of Products
-- ----------------------------
-- Thêm dữ liệu mẫu vào bảng Products với CatID từ 1 đến 7
-- Inserting 10 sample records into Products table with longer FullDes descriptions
-- Inserting 10 records into the Products table
-- Generate 10 records for the Products table
INSERT INTO Products (Name, TinyDes, FullDes, Price, CatID, Quantity)
VALUES
    ('Samsung Galaxy S20', 'Flagship smartphone', 'The Samsung Galaxy S20 is a powerful flagship smartphone featuring a high-resolution display, advanced camera system, and fast performance. Experience cutting-edge technology with this premium device.', 999.99, 2, 50),

    ('Canon EOS Rebel T7i', 'Entry-level DSLR camera', 'The Canon EOS Rebel T7i is an excellent choice for photography enthusiasts. It boasts a 24.2-megapixel sensor, fast autofocus, and intuitive controls, making it ideal for capturing stunning images.', 699.99, 3, 20),

    ('Lenovo ThinkPad X1 Carbon', 'Ultrabook for professionals', 'The Lenovo ThinkPad X1 Carbon is a sleek and powerful ultrabook designed for business users. It offers a lightweight carbon fiber chassis, vibrant display, and long battery life, perfect for on-the-go productivity.', 1499.99, 5, 30),

    ('Silver Bracelet with Gemstones', 'Handcrafted jewelry', 'Elegant and timeless, this silver bracelet features a stunning arrangement of gemstones. Each piece is carefully handcrafted by skilled artisans, making it a unique addition to any jewelry collection.', 299.99, 6, 15),

    ('Men''s Leather Jacket', 'Classic outerwear', 'A stylish and durable leather jacket for men, crafted from high-quality leather. This classic piece features a timeless design that never goes out of style, suitable for various occasions.', 199.99, 4, 10),

    ('Dell 27" 4K Monitor', 'High-resolution display', 'Immerse yourself in stunning visuals with the Dell 27" 4K Monitor. Featuring vibrant colors and crisp details, this monitor is perfect for creative professionals and multimedia enthusiasts.', 599.99, 5, 25),

    ('Novel: The Great Gatsby', 'Classic American literature', 'Experience the Roaring Twenties with F. Scott Fitzgerald''s timeless masterpiece, The Great Gatsby. This novel explores themes of love, wealth, and the American Dream, making it a must-read.', 14.99, 1, 40),

    ('Women''s Running Shoes', 'Comfortable footwear', 'Achieve your fitness goals with these women''s running shoes. Designed for comfort and performance, they feature cushioned soles and breathable materials, ideal for running and workouts.', 79.99, 4, 35),

    ('Kitchen Blender', 'Versatile appliance', 'Make delicious smoothies, soups, and sauces with this high-performance kitchen blender. Its powerful motor and durable blades ensure smooth blending every time, making meal preparation effortless.', 49.99, 7, 15),

    ('Wireless Bluetooth Earbuds', 'True wireless audio', 'Enjoy wireless freedom with these Bluetooth earbuds. They deliver crystal-clear sound and a comfortable fit, perfect for music lovers and commuters alike.', 79.99, 2, 50),
	    ('Apple MacBook Pro 13"', 'Powerful laptop for professionals', 'The Apple MacBook Pro 13" is a versatile laptop designed for professionals and creatives. It features a stunning Retina display, powerful performance, and all-day battery life, making it ideal for work and entertainment.', 1499.99, 5, 15),

    ('Diamond Engagement Ring', 'Exquisite symbol of love', 'Celebrate a special moment with this diamond engagement ring. Crafted with precision and elegance, it features a sparkling diamond centerpiece that symbolizes eternal love and commitment.', 3999.99, 6, 5),

    ('Nike Air Jordan Sneakers', 'Iconic basketball shoes', 'Step out in style with the Nike Air Jordan sneakers. These iconic basketball shoes combine retro design with modern comfort, making them a favorite among sneaker enthusiasts and athletes.', 199.99, 4, 20),

    ('Sony PlayStation 5', 'Next-gen gaming console', 'Experience the future of gaming with the Sony PlayStation 5. Featuring cutting-edge graphics, lightning-fast load times, and immersive gameplay, this console delivers unparalleled entertainment.', 499.99, 7, 10),

    ('Canon PIXMA Wireless Printer', 'Versatile home office printer', 'Print, scan, and copy with ease using the Canon PIXMA wireless printer. It offers convenient wireless connectivity, high-quality printing, and compact design, perfect for home office setups.', 129.99, 5, 30),

    ('Toshiba 55" 4K Smart TV', 'Immersive home entertainment', 'Transform your living room into a home theater with the Toshiba 55" 4K Smart TV. Featuring vibrant colors, smart features, and crisp resolution, this TV delivers an immersive viewing experience.', 699.99, 3, 12),

    ('Fitness Tracker Watch', 'Stay active and connected', 'Monitor your fitness goals and stay connected with this versatile fitness tracker watch. It tracks your steps, heart rate, and sleep patterns while keeping you notified of calls and messages.', 79.99, 2, 40),

    ('Leather Messenger Bag', 'Stylish and functional accessory', 'Carry your essentials in style with this leather messenger bag. It offers ample storage, durable construction, and a timeless design that complements both casual and professional attire.', 129.99, 4, 15),

    ('Cookware Set', 'Essential kitchen utensils', 'Upgrade your cooking experience with this comprehensive cookware set. It includes pots, pans, and utensils crafted from premium materials, ensuring even heat distribution and long-lasting performance.', 199.99, 7, 8),

    ('Wireless Gaming Mouse', 'Precision gaming accessory', 'Enhance your gaming performance with this wireless gaming mouse. Featuring customizable buttons, ergonomic design, and lag-free connectivity, it provides precision and comfort during intense gameplay.', 49.99, 5, 25),
	
	('HP Envy x360 Convertible Laptop', 'Versatile 2-in-1 laptop', 'The HP Envy x360 is a versatile convertible laptop that adapts to your needs. Use it as a laptop for work, flip it into tent mode for presentations, or fold it into tablet mode for creative tasks. With powerful performance and a sleek design, its perfect for multitasking.', 899.99, 5, 18),

    ('Silver Pendant Necklace', 'Elegant jewelry accessory', 'Add a touch of sophistication to your outfit with this silver pendant necklace. Featuring a minimalist design and high-quality craftsmanship, its a timeless accessory suitable for any occasion.', 149.99, 6, 25),

    ('Adidas Ultraboost Running Shoes', 'Premium running footwear', 'Experience exceptional comfort and performance with Adidas Ultraboost running shoes. They feature responsive cushioning, breathable materials, and a stylish design, making them ideal for running enthusiasts.', 179.99, 4, 30),

    ('Samsung 55" QLED Smart TV', 'Immersive entertainment experience', 'Immerse yourself in stunning visuals and vibrant colors with the Samsung 55" QLED Smart TV. Featuring Quantum Dot technology and smart functionality, it delivers an unparalleled entertainment experience.', 1199.99, 3, 10),

    ('Smart Home Security Camera', 'Monitor your home remotely', 'Enhance your home security with this smart home security camera. It offers live streaming, motion detection, and two-way audio communication, allowing you to monitor your home from anywhere.', 79.99, 7, 20),

    ('Cuisinart Coffee Maker', 'Brew delicious coffee at home', 'Start your day right with the Cuisinart coffee maker. It brews rich and flavorful coffee, features programmable settings, and has a sleek design that complements any kitchen.', 89.99, 7, 15),

    ('Wireless Noise-Cancelling Headphones', 'Immersive audio experience', 'Enjoy superior sound quality and immersive audio with wireless noise-cancelling headphones. They block out external noise, offer long battery life, and provide exceptional comfort for extended use.', 249.99, 2, 15),

    ('Designer Leather Wallet', 'Luxurious accessory for men', 'Carry your essentials in style with this designer leather wallet. Crafted from premium leather, it features multiple compartments for cards and cash, combining functionality with luxury.', 129.99, 6, 12),

    ('Portable Bluetooth Speaker', 'Compact and powerful audio', 'Take your music anywhere with this portable Bluetooth speaker. It delivers crisp sound, offers wireless connectivity, and has a durable design that withstands outdoor use.', 59.99, 7, 25),

    ('Desktop Gaming PC', 'High-performance gaming rig', 'Experience gaming at its best with this desktop gaming PC. Equipped with powerful hardware and customizable features, it delivers smooth gameplay and exceptional graphics for demanding titles.', 1499.99, 5, 8)

---------------------------
-- Table structure for [dbo].[Orders]
-- ----------------------------
CREATE TABLE Orders(
	Id int IDENTITY(1,1) primary key,
	OrderDate datetime NOT NULL,
	UserID int NOT NULL, 
	Total float NOT NULL,
	
	foreign key(UserID) references Users(Id),
)
-- ----------------------------
-- Records of Orders
-- ----------------------------
INSERT INTO Orders (OrderDate, UserID, Total) VALUES (N'2014-03-14 00:00:00.000', 1, 3600000);
INSERT INTO Orders (OrderDate, UserID, Total) VALUES (N'2014-03-14 00:00:00.000', 1, 800000);

-- ----------------------------
-- Table structure for [dbo].[OrderDetails]
-- ----------------------------
CREATE TABLE OrderDetails (
	ID int IDENTITY(1,1) primary key,
	OrderID int NOT NULL ,
	ProID int NOT NULL ,
	Quantity float NOT NULL ,
	Price float NOT NULL ,
	Amount float NOT NULL,
	
	foreign key (OrderID) references Orders(Id),
	foreign key (ProID) references Products(Id),
)
-- ----------------------------
-- Records of OrderDetails
-- ----------------------------
INSERT INTO OrderDetails (OrderID, ProID, Quantity, Price, Amount) VALUES (1, 1, 2, 1500000, 3000000);
INSERT INTO OrderDetails (OrderID, ProID, Quantity, Price, Amount) VALUES (1, 2, 2, 300000, 600000);
INSERT INTO OrderDetails (OrderID, ProID, Quantity, Price, Amount) VALUES (2, 1, 1, 1500000, 1500000);
INSERT INTO OrderDetails (OrderID, ProID, Quantity, Price, Amount) VALUES (2, 2, 1, 300000, 300000);