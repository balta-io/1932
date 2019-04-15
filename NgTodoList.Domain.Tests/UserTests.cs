using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NgTodoList.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Novo Usuário")]
        public void O_nome_deve_ser_valido()
        {
            var user = new User("", "andrebaltieri@hotmail.com", "xpto0030");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Novo Usuário")]
        public void O_email_deve_ser_valido()
        {
            var user = new User("André Baltieri", "andrebaltieri", "xpto0030");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        public void O_id_deve_ser_zero()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            Assert.AreEqual(0, user.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Novo Usuário")]
        public void A_senha_deve_ser_valida()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "123");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Novo Usuário")]
        public void A_senha_nao_pode_ser_vazia()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "");
        }
    }
    
    [TestClass]
    public class Ao_alterar_senha
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao alterar senha")]
        public void A_nova_senha_nao_pode_ser_igual_a_anterior()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.ChangePassword("andrebaltieri", "xpto0030", "xpto0030", "xpto0030");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao alterar senha")]
        public void A_nova_senha_deve_ser_valida()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.ChangePassword("andrebaltieri", "xpto0030", "00", "00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao alterar senha")]
        public void A_confirmacao_de_senha_deve_ser_valida()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.ChangePassword("andrebaltieri", "xpto0030", "wpt0328", "wpt0327");
        }
    }

    [TestClass]
    public class Ao_resetar_a_senha
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao resetar senha")]
        public void O_usuario_deve_ser_valido()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.ResetPassword("asd");
        }
    }

    [TestClass]
    public class Ao_se_autenticar
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao se autenticar")]
        public void O_usuario_deve_estar_ativo()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.Authenticate("andrebaltieri", "xpto0030");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao se autenticar")]
        public void A_opcao_deve_restaurar_sua_senha_deve_ser_falsa()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.Authenticate("andrebaltieri", "xpto0030");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao se autenticar")]
        public void O_usuario_e_senha_devem_ser_validos()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.Authenticate("andrebaltieri", "andrebaltieri");
        }
    }

    [TestClass]
    public class Ao_alterar_as_informacoes
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao editar as informações")]
        public void O_nome_deve_ser_valido()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.UpdateInfo("", "andrebaltieri@hotmail.com");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [TestCategory("User - Ao editar as informações")]
        public void O_email_deve_ser_valido()
        {
            var user = new User("André Baltieri", "andrebaltieri@hotmail.com", "xpto0030");
            user.UpdateInfo("André Baltieri", "email");
        }

    }
}
