-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Nov 03, 2017 at 12:42 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Library`
--

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `authorname` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`id`, `authorname`) VALUES
(46, 'Shakespeare'),
(47, 'Bob Roberts'),
(48, 'Billy Bob'),
(49, 'Steven Roberts'),
(50, 'fsdff');

-- --------------------------------------------------------

--
-- Table structure for table `authors_books`
--

CREATE TABLE `authors_books` (
  `id` int(11) NOT NULL,
  `catalog_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `authors_books`
--

INSERT INTO `authors_books` (`id`, `catalog_id`, `author_id`, `book_id`) VALUES
(13, 0, 21, 73),
(14, 0, 21, 74),
(15, 0, 21, 75),
(16, 0, 23, 76),
(17, 0, 23, 77),
(18, 0, 23, 78),
(19, 0, 25, 79),
(20, 0, 25, 80),
(21, 0, 25, 81),
(23, 0, 27, 83),
(24, 0, 28, 84),
(25, 0, 29, 84),
(26, 0, 30, 85),
(27, 0, 30, 86),
(28, 0, 31, 87),
(29, 0, 31, 88),
(30, 0, 31, 89),
(36, 0, 34, 95),
(37, 0, 34, 96),
(38, 0, 36, 97),
(39, 0, 36, 98),
(40, 0, 35, 99),
(41, 0, 35, 100),
(42, 0, 37, 95),
(43, 0, 38, 101),
(44, 0, 38, 102),
(45, 0, 38, 103),
(46, 0, 40, 104),
(47, 0, 46, 105),
(48, 0, 46, 106),
(49, 0, 47, 107),
(50, 0, 50, 107),
(51, 0, 48, 108);

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `titlename` varchar(255) NOT NULL,
  `copies` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `titlename`, `copies`) VALUES
(95, 'Jurassic Park', 0),
(96, 'Congo', 1),
(97, 'Romeo Juliet', 84),
(98, 'Othello', -11),
(99, 'Jurassic Park', -1),
(100, 'ewofijweiofj', 31),
(101, 'IT', -2),
(102, 'Jurassic Park', 0),
(103, 'National Geographic', 0),
(104, 'Cujo', 0),
(105, 'IT', 83),
(106, 'IT', 83),
(107, 'Jurassic Park', 32),
(108, 'Cujo', 13212);

-- --------------------------------------------------------

--
-- Table structure for table `books_copies`
--

CREATE TABLE `books_copies` (
  `id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `copy_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `checkoutDate` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `patrons`
--

CREATE TABLE `patrons` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `patronname` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `patrons`
--

INSERT INTO `patrons` (`id`, `patronname`) VALUES
(1, 'Jhon'),
(2, 'Jhon'),
(3, 'Jhon'),
(4, 'Jhon'),
(5, 'Jhon'),
(6, 'Sravy');

-- --------------------------------------------------------

--
-- Table structure for table `patrons_books`
--

CREATE TABLE `patrons_books` (
  `id` int(11) NOT NULL,
  `patron_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `patron_copies`
--

CREATE TABLE `patron_copies` (
  `id` int(11) NOT NULL,
  `patron_id` int(11) NOT NULL,
  `copy_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `authors_books`
--
ALTER TABLE `authors_books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `books_copies`
--
ALTER TABLE `books_copies`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `copies`
--
ALTER TABLE `copies`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `patrons`
--
ALTER TABLE `patrons`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `patrons_books`
--
ALTER TABLE `patrons_books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patron_copies`
--
ALTER TABLE `patron_copies`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;
--
-- AUTO_INCREMENT for table `authors_books`
--
ALTER TABLE `authors_books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;
--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=109;
--
-- AUTO_INCREMENT for table `books_copies`
--
ALTER TABLE `books_copies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `copies`
--
ALTER TABLE `copies`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `patrons`
--
ALTER TABLE `patrons`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `patrons_books`
--
ALTER TABLE `patrons_books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `patron_copies`
--
ALTER TABLE `patron_copies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
