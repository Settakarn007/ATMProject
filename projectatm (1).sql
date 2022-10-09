-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2022 at 04:34 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projectatm`
--

-- --------------------------------------------------------

--
-- Table structure for table `admindb`
--

CREATE TABLE `admindb` (
  `NumAdd` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admindb`
--

INSERT INTO `admindb` (`NumAdd`) VALUES
(1111);

-- --------------------------------------------------------

--
-- Table structure for table `regis`
--

CREATE TABLE `regis` (
  `AccNum` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `FaName` varchar(100) NOT NULL,
  `Dob` varchar(100) NOT NULL,
  `Phone` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `Education` varchar(100) NOT NULL,
  `Occupation` varchar(100) NOT NULL,
  `Pin` varchar(100) NOT NULL,
  `Balance` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `regis`
--

INSERT INTO `regis` (`AccNum`, `Name`, `FaName`, `Dob`, `Phone`, `Address`, `Education`, `Occupation`, `Pin`, `Balance`) VALUES
('1985', 'sedffasf', 'fsdfdsfsd', '30 สิงหาคม 2565', '0973259761', 'sfsdss', 'Under Graduate', 'student', '12345', '4961500');

-- --------------------------------------------------------

--
-- Table structure for table `tran`
--

CREATE TABLE `tran` (
  `Tid` int(20) NOT NULL,
  `AccNum` varchar(50) NOT NULL,
  `Type` varchar(50) NOT NULL,
  `Amount` int(20) NOT NULL,
  `Balance` int(20) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tran`
--

INSERT INTO `tran` (`Tid`, `AccNum`, `Type`, `Amount`, `Balance`, `timestamp`) VALUES
(1, '1985', 'FashCash', 500, 4993000, '2022-08-30 14:55:50'),
(2, '1985', 'FashCash', 500, 4992500, '2022-08-30 14:55:55'),
(3, '1985', 'FashCash', 1000, 4991500, '2022-08-30 14:56:11'),
(4, '1985', 'WithDraw', 50000, 4941500, '2022-08-30 14:56:27'),
(5, '1985', 'Deposit', 20000, 4961500, '2022-08-30 14:56:54');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tran`
--
ALTER TABLE `tran`
  ADD PRIMARY KEY (`Tid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tran`
--
ALTER TABLE `tran`
  MODIFY `Tid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
