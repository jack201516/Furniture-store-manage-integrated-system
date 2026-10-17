-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2026-07-02 16:07:30
-- 伺服器版本： 10.4.32-MariaDB
-- PHP 版本： 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `plfc`
--

-- --------------------------------------------------------

--
-- 資料表結構 `complaint`
--

CREATE TABLE `complaint` (
  `ComplaintID` varchar(10) NOT NULL,
  `CustomerID` varchar(10) NOT NULL,
  `OrderID` varchar(10) NOT NULL,
  `ComplaintContent` varchar(500) NOT NULL,
  `States` varchar(50) NOT NULL,
  `oitemID` varchar(100) DEFAULT NULL,
  `Handling` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `customer`
--

CREATE TABLE `customer` (
  `CustomerID` varchar(10) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `number` int(11) DEFAULT NULL,
  `email` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customer`
--

INSERT INTO `customer` (`CustomerID`, `Name`, `Address`, `number`, `email`) VALUES
('C000001', 'apple', '18 Tsing Wun Rd, Tuen Mun', 12345678, 'abc@gmail.com');

-- --------------------------------------------------------

--
-- 資料表結構 `delivery`
--

CREATE TABLE `delivery` (
  `DeliveryID` varchar(100) NOT NULL,
  `OrderID` varchar(10) NOT NULL,
  `CustomerID` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `goods`
--

CREATE TABLE `goods` (
  `GoodsID` varchar(10) NOT NULL,
  `OrderID` varchar(10) NOT NULL,
  `oitemID` varchar(100) DEFAULT NULL,
  `state` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `material`
--

CREATE TABLE `material` (
  `MaterialID` varchar(10) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `QTY` double(255,1) NOT NULL,
  `price` int(11) NOT NULL,
  `data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `morder`
--

CREATE TABLE `morder` (
  `MoID` varchar(10) NOT NULL,
  `MaterialID` varchar(10) NOT NULL,
  `Qty` int(10) NOT NULL,
  `state` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `order`
--

CREATE TABLE `order` (
  `OrderID` varchar(10) NOT NULL,
  `ProductID` varchar(10) NOT NULL,
  `CustomerID` varchar(10) NOT NULL,
  `DeliveryID` varchar(10) NOT NULL,
  `States` varchar(10) DEFAULT NULL,
  `dDATA` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `orderitem`
--

CREATE TABLE `orderitem` (
  `oitemID` varchar(100) NOT NULL,
  `pid` text NOT NULL,
  `cid` text NOT NULL,
  `qty` int(11) NOT NULL,
  `OrderID` varchar(10) DEFAULT NULL,
  `state` text DEFAULT NULL,
  `custom` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `product`
--

CREATE TABLE `product` (
  `ProductID` varchar(10) NOT NULL,
  `Price` varchar(10) NOT NULL,
  `ProductName` varchar(50) NOT NULL,
  `describle` text DEFAULT NULL,
  `typ` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `product`
--

INSERT INTO `product` (`ProductID`, `Price`, `ProductName`, `describle`, `typ`) VALUES
('P000001', '$100', 'White table', 'size  50*50', 'Table');

-- --------------------------------------------------------

--
-- 資料表結構 `user`
--

CREATE TABLE `user` (
  `UserID` varchar(50) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL,
  `Department` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `user`
--

INSERT INTO `user` (`UserID`, `Name`, `Password`, `Department`) VALUES
('U00001', 'Apple', 'a1234', 'sales'),
('U00002', 'peter', 'a1234', 'design'),
('U00003', 'lisa', 'a1234', 'production'),
('U00004', 'Jack', 'a1234', 'whouse'),
('U00005', 'tony', 'a1234', 'shipping'),
('U00006', 'YY', 'a1234', 'manager');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `complaint`
--
ALTER TABLE `complaint`
  ADD UNIQUE KEY `ComplaintID` (`ComplaintID`);

--
-- 資料表索引 `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- 資料表索引 `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`DeliveryID`);

--
-- 資料表索引 `goods`
--
ALTER TABLE `goods`
  ADD PRIMARY KEY (`GoodsID`);

--
-- 資料表索引 `material`
--
ALTER TABLE `material`
  ADD PRIMARY KEY (`MaterialID`);

--
-- 資料表索引 `morder`
--
ALTER TABLE `morder`
  ADD PRIMARY KEY (`MoID`);

--
-- 資料表索引 `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`OrderID`);

--
-- 資料表索引 `orderitem`
--
ALTER TABLE `orderitem`
  ADD PRIMARY KEY (`oitemID`);

--
-- 資料表索引 `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ProductID`);

--
-- 資料表索引 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
