using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NgTodoList.Domain.Tests
{
    [TestClass]
    public class Dada_uma_nova_tarefa
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Todo - Dada uma nova tarefa")]
        public void O_titulo_deve_ser_valido()
        {
            var todo = new Todo("", 1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("Todo - Dada uma nova tarefa")]
        public void O_usuario_deve_ser_valido()
        {
            var todo = new Todo("Tarefa 1", 0);
        }

        [TestMethod]
        public void A_mesma_nao_deve_estar_concluida()
        {
            var todo = new Todo("Tarefa 1", 1);
            Assert.AreEqual(false, todo.Done);
        }
    }
}
