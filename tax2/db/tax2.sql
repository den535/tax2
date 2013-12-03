-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Дек 03 2013 г., 16:19
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `tax2`
--

-- --------------------------------------------------------

--
-- Структура таблицы `sotrudnik`
--

CREATE TABLE IF NOT EXISTS `sotrudnik` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `first_name` text NOT NULL,
  `last_name` text NOT NULL,
  `doljnost` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

-- --------------------------------------------------------

--
-- Структура таблицы `tc`
--

CREATE TABLE IF NOT EXISTS `tc` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `color` text NOT NULL,
  `nomer` int(8) NOT NULL,
  `marka` varchar(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

-- --------------------------------------------------------

--
-- Структура таблицы `tip_vizova`
--

CREATE TABLE IF NOT EXISTS `tip_vizova` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `vxod/vixod` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

-- --------------------------------------------------------

--
-- Структура таблицы `vizov`
--

CREATE TABLE IF NOT EXISTS `vizov` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `id_sotrudnika` int(8) NOT NULL,
  `id_tip_vizova` int(8) NOT NULL,
  `id_zakaza` int(8) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_sotrudnika` (`id_sotrudnika`,`id_tip_vizova`,`id_zakaza`),
  KEY `id_tip_vizova` (`id_tip_vizova`),
  KEY `id_zakaza` (`id_zakaza`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

-- --------------------------------------------------------

--
-- Структура таблицы `zakaz`
--

CREATE TABLE IF NOT EXISTS `zakaz` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `id_sotrudnika` int(8) NOT NULL,
  `id_TC` int(8) NOT NULL,
  `A` varchar(11) NOT NULL,
  `B` varchar(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_sotrudnika` (`id_sotrudnika`,`id_TC`),
  KEY `id_TC` (`id_TC`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `vizov`
--
ALTER TABLE `vizov`
  ADD CONSTRAINT `vizov_ibfk_1` FOREIGN KEY (`id_tip_vizova`) REFERENCES `tip_vizova` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `vizov_ibfk_2` FOREIGN KEY (`id_zakaza`) REFERENCES `zakaz` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `vizov_ibfk_3` FOREIGN KEY (`id_sotrudnika`) REFERENCES `sotrudnik` (`id`);

--
-- Ограничения внешнего ключа таблицы `zakaz`
--
ALTER TABLE `zakaz`
  ADD CONSTRAINT `zakaz_ibfk_1` FOREIGN KEY (`id_sotrudnika`) REFERENCES `sotrudnik` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `zakaz_ibfk_2` FOREIGN KEY (`id_TC`) REFERENCES `tc` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
