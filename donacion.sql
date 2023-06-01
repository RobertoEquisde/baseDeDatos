-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 01-06-2023 a las 16:46:28
-- Versión del servidor: 5.6.13
-- Versión de PHP: 5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `donacion`
--
CREATE DATABASE IF NOT EXISTS `donacion` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `donacion`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `donantes`
--

CREATE TABLE IF NOT EXISTS `donantes` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` tinytext NOT NULL,
  `apellido` tinytext NOT NULL,
  `edad` int(11) NOT NULL,
  `genero` tinytext NOT NULL,
  `tipoSangre` tinytext NOT NULL,
  `direccion` tinytext NOT NULL,
  `telefono` tinytext NOT NULL,
  `correoElectronico` tinytext NOT NULL,
  `ultimaDonacion` date NOT NULL,
  `restricciones` tinytext NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Volcado de datos para la tabla `donantes`
--

INSERT INTO `donantes` (`ID`, `nombre`, `apellido`, `edad`, `genero`, `tipoSangre`, `direccion`, `telefono`, `correoElectronico`, `ultimaDonacion`, `restricciones`) VALUES
(1, 'Juan', 'Gómez', 25, 'Masculino', 'O+', 'Calle 123, Ciudad', '+52 1 55 12345678', 'juan@gmail.com', '2023-05-15', 'Ninguna'),
(2, 'María', 'López', 30, 'Femenino', 'A-', 'Avenida Principal, Ciudad', '+52 1 55 23456789', 'maria@yahoo.com', '2023-04-20', 'Alergia a los lácteos'),
(3, 'Carlos', 'Rodríguez', 45, 'Masculino', 'B+', 'Calle 456, Ciudad', '+52 1 55 34567890', 'carlos@outlook.com', '2023-03-10', 'Hipertensión'),
(4, 'Laura', 'Fernández', 35, 'Femenino', 'O-', 'Avenida Central, Ciudad', '+52 1 55 45678901', 'laura@gmail.com', '2023-02-05', 'Ninguna'),
(5, 'Pedro', 'Martínez', 28, 'Masculino', 'AB+', 'Calle 789, Ciudad', '+52 1 55 56789012', 'pedro@yahoo.com', '2023-01-01', 'Diabetes'),
(6, 'Ana', 'González', 42, 'Femenino', 'A+', 'Avenida Norte, Ciudad', '+52 1 55 67890123', 'ana@outlook.com', '2022-12-25', 'Ninguna'),
(7, 'Luis', 'Hernández', 33, 'Masculino', 'B-', 'Calle Sur, Ciudad', '+52 1 55 78901234', 'luis@gmail.com', '2022-11-20', 'Alergia al polen'),
(8, 'Sofía', 'Díaz', 27, 'Femenino', 'O+', 'Avenida Oeste, Ciudad', '+52 1 55 89012345', 'sofia@yahoo.com', '2022-10-15', 'Ninguna'),
(9, 'Diego', 'Sánchez', 38, 'Masculino', 'AB-', 'Calle Este, Ciudad', '+52 1 55 90123456', 'diego@outlook.com', '2022-09-10', 'Ninguna'),
(10, 'Isabel', 'Vargas', 31, 'Femenino', 'A+', 'Avenida 123, Ciudad', '+52 1 55 01234567', 'isabel@gmail.com', '2022-08-05', 'Alergia a los frutos secos'),
(11, 'Mario', 'Mendoza', 39, 'Masculino', 'B-', 'Calle 456, Ciudad', '+52 1 55 12345678', 'mario@yahoo.com', '2022-07-01', 'Ninguna'),
(12, 'Carolina', 'Pérez', 29, 'Femenino', 'O+', 'Avenida Principal, Ciudad', '+52 1 55 23456789', 'carolina@outlook.com', '2022-06-25', 'Hipotiroidismo'),
(13, 'Andrés', 'Romero', 36, 'Masculino', 'AB-', 'Calle 789, Ciudad', '+52 1 55 34567890', 'andres@gmail.com', '2022-05-20', 'Ninguna'),
(14, 'Julia', 'Gutiérrez', 41, 'Femenino', 'A+', 'Avenida Central, Ciudad', '+52 1 55 45678901', 'julia@yahoo.com', '2022-04-15', 'Ninguna'),
(15, 'Eduardo', 'Navarro', 34, 'Masculino', 'B-', 'Calle Este, Ciudad', '+52 1 55 56789012', 'eduardo@outlook.com', '2022-03-10', 'Ninguna'),
(16, 'Gabriela', 'Silva', 26, 'Femenino', 'O+', 'Avenida Oeste, Ciudad', '+52 1 55 67890123', 'gabriela@gmail.com', '2022-02-05', 'Ninguna'),
(17, 'Roberto', 'Ortega', 37, 'Masculino', 'AB-', 'Calle Sur, Ciudad', '+52 1 55 78901234', 'roberto@yahoo.com', '2022-01-01', 'Ninguna'),
(18, 'Alejandra', 'Torres', 32, 'Femenino', 'A+', 'Avenida Norte, Ciudad', '+52 1 55 89012345', 'alejandra@outlook.com', '2021-12-25', 'Ninguna'),
(19, 'Javier', 'Rojas', 43, 'Masculino', 'B-', 'Calle 123, Ciudad', '+52 1 55 90123456', 'javier@gmail.com', '2021-11-20', 'Ninguna'),
(20, 'roberto', 'ruvalcaba', 22, 'Masculino', 'O+', 'san simon tolnahuac', '5568779892', 'robertu131@gmail.com', '2022-03-02', 'ninguna');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
