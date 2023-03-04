-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 04 Mar 2023, 16:37:02
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `frigos`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `frigoslogin`
--

CREATE TABLE `frigoslogin` (
  `fid` int(11) NOT NULL,
  `fusername` varchar(50) NOT NULL,
  `fpassword` varchar(50) NOT NULL,
  `femail` varchar(100) NOT NULL,
  `ftarih` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `frigoslogin`
--

INSERT INTO `frigoslogin` (`fid`, `fusername`, `fpassword`, `femail`, `ftarih`) VALUES
(1, 'asd', 'asd', 'asd', '2022-05-20');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `money`
--

CREATE TABLE `money` (
  `moneyId` int(11) NOT NULL,
  `fidFK` int(11) NOT NULL,
  `fgalıs` text NOT NULL,
  `fgsatıs` text NOT NULL,
  `fgsavedate` date NOT NULL,
  `fgkoduFK` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `money`
--

INSERT INTO `money` (`moneyId`, `fidFK`, `fgalıs`, `fgsatıs`, `fgsavedate`, `fgkoduFK`) VALUES
(1, 1, '18.8927', '18.8587', '2023-03-04', 'USD');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `moneyinfo`
--

CREATE TABLE `moneyinfo` (
  `fgid` int(11) NOT NULL,
  `dgName` varchar(50) NOT NULL,
  `fgalıs` double NOT NULL,
  `fgsatıs` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `frigoslogin`
--
ALTER TABLE `frigoslogin`
  ADD PRIMARY KEY (`fid`);

--
-- Tablo için indeksler `money`
--
ALTER TABLE `money`
  ADD PRIMARY KEY (`moneyId`);

--
-- Tablo için indeksler `moneyinfo`
--
ALTER TABLE `moneyinfo`
  ADD PRIMARY KEY (`fgid`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `frigoslogin`
--
ALTER TABLE `frigoslogin`
  MODIFY `fid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `money`
--
ALTER TABLE `money`
  MODIFY `moneyId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
