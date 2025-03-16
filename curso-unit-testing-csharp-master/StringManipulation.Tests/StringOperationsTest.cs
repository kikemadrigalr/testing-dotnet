﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulation.Tests
{
    //Clases de rueba deben ser publicas
    public class StringOperationsTest
    {
        [Fact(Skip = "Esta prueba no es valida en este momento")]
        public void ConcatenateStrings()
        {
            //ARRANGE
            //Objeto del tipo de la clase que estaos probando
            StringOperations ops = new StringOperations();

            //ACT
            //gardar el resultado de la prueba, apuntando al metodo que se va a probar
            //pasando el numero de parametros que espera el metodo
            var result = ops.ConcatenateStrings("Hello", "Platzi");

            //ASSERT
            //comprobar que el metodo retorne lo que se espera
            //y se compara con el resultado esperado
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            //ARRANGE
            StringOperations ops = new StringOperations();

            //ACT
            bool result = ops.IsPalindrome("ama");

            //ASSERT     
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            //ARRANGE
            StringOperations ops = new StringOperations();

            //ACT
            bool result = ops.IsPalindrome("hello");

            //ASSERT     
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            //arrange
            StringOperations ops = new StringOperations();

            //ACT
            var result = ops.QuantintyInWords("car", 10);

            //Asserts

            //Comprobar que la cadena empiece con na palabra en particular
            Assert.StartsWith("diez", result);

            //comprobar que contenga una cedana en especifico
            Assert.Contains("car", result);
        }

        [Theory]
        [InlineData("dos", 2)]
        [InlineData("tres", 3)]
        [InlineData("diez", 10)]
        [InlineData("mil doscientos", 1200)]
        public void QuantintyInWords_Multiple(string input, int expected)
        {
            //arrange
            StringOperations ops = new StringOperations();

            //ACT
            var result = ops.QuantintyInWords(input, expected);

            Assert.StartsWith(input, result);
            //Assert.Contains("car", result);
        }

        //test para pruebas que devuelven excepciones
        [Fact]
        public void GetStringLength_Exception()
        {
            //Arrange
            StringOperations ops = new StringOperations();

            //No Se espera obtener resultados ya que se espera obtener una exception

            //Assert

            //se ejecuta la funcion usando delegado
            Assert.ThrowsAny<ArgumentNullException>(() => ops.GetStringLength(null));
        }

        /// <summary>
        /// Caso básico: Comprobar que el método devuelve la longitud correcta de una cadena válida.
        /// </summary>
        [Fact]
        public void GetStringLength_ValidString_ReturnsLength()
        {
            // Arrange
            var input = "Hello";
            var expected = 5;
            StringOperations ops = new StringOperations();

            // Act
            var result = ops.GetStringLength(input);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Caso de cadena vacía: Asegurarse de que el método devuelve 0 para una cadena vacía.
        /// </summary>
        [Fact]
        public void GetStringLength_EmptyString_ReturnsZero()
        {
            // Arrange
            var input = string.Empty;
            var expected = 0;
            StringOperations ops = new StringOperations();

            // Act
            var result = ops.GetStringLength(input);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Caso de valor nulo: Verificar que se lanza una excepción ArgumentNullException cuando el parámetro str es null.
        /// </summary>
        [Fact]
        public void GetStringLength_NullString_ThrowsArgumentNullException()
        {
            StringOperations ops = new StringOperations();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ops.GetStringLength(null));
        }

        /// <summary>
        /// Cadena con espacios: Confirmar que la longitud se calcula correctamente para cadenas que contienen espacios.
        /// </summary>
        [Fact]
        public void GetStringLength_StringWithSpaces_ReturnsCorrectLength()
        {
            // Arrange
            var input = "Hello World";
            var expected = 11;
            StringOperations ops = new StringOperations();

            // Act
            var result = ops.GetStringLength(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            //ArRange
            string input = "Hello";
            StringOperations ops = new StringOperations();

            //Act & Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => ops.TruncateString(input, -3));

        }

        [Fact]
        public void TruncateString()
        {
            //ArRange
            string input = "Hello";
            string expected = "Hel";
            StringOperations ops = new StringOperations();

            //ACT
            var result = ops.TruncateString(input, 3);

            //Act & Assert
            Assert.Equal(expected, result);

        }

        //reutilizar la misma estructura de prueba ara varias comprobaciones
        [Theory]
        [InlineData("V", 5)]
        [InlineData("C", 100)]
        [InlineData("M", 1000)]
        [InlineData("MCMXCIX", 1999)]
        public void FromRomanToNumber(string romanNember, int expected)
        {
            StringOperations ops = new StringOperations();

            int result = ops.FromRomanToNumber(romanNember);

            Assert.Equal(expected, result);
        }




    }
}
