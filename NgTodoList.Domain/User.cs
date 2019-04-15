using NgTodoList.Utils.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace NgTodoList.Domain
{
    public class User
    {
        private IList<Todo> _todos;

        protected User() { }

        public User(string name, string email, string password)
        {
            Contract.Requires<Exception>(name.Length > 3, "O nome deve conter mais de 3 caracteres");
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");
            Contract.Requires<Exception>(password.Length >= 6, "A senha deve conter pelo menos 6 caracteres");

            this.Id = 0;
            this.Name = name;
            this.Email = email;
            this.Password = EncryptHelper.Encrypt(password);
            this.IsActive = true;
            this._todos = new List<Todo>();
            this.Todos = new List<Todo>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsActive { get; protected set; }
        public virtual ICollection<Todo> Todos
        {
            get { return _todos; }
            protected set { _todos = new List<Todo>(value); }
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            Contract.Requires<Exception>(this.Password != EncryptHelper.Encrypt(newPassword), "A nova senha não pode ser igual a anterior");
            Contract.Requires<Exception>(newPassword.Length >= 6, "A senha deve conter pelo menos 6 caracteres");
            Contract.Requires<Exception>(newPassword == confirmNewPassword, "As senhas informadas não coincidem");

            this.Authenticate(email, password);

            var newpass = EncryptHelper.Encrypt(newPassword);
            this.Password = newpass;
        }

        public string ResetPassword(string email)
        {
            Contract.Requires<Exception>(this.Email.ToLower() == email.ToLower(), "Usuário inválido");

            var password = System.Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = EncryptHelper.Encrypt(password);

            return password;
        }

        public void Authenticate(string email, string password)
        {
            Contract.Requires<Exception>(this.IsActive, "Este usuário está inativo");
            Contract.Requires<Exception>(this.Email.ToLower() == email.ToLower(), "Usuário ou senha inválidos");
            Contract.Requires<Exception>(this.Password == EncryptHelper.Encrypt(password), "Usuário ou senha inválidos");
        }

        public void UpdateInfo(string name, string email)
        {
            Contract.Requires<Exception>(name.Length > 3, "O nome deve conter mais de 3 caracteres");
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");

            this.Name = name;
            this.Email = email;
        }

        public void SyncTodos(IList<Todo> todos)
        {
            Contract.Requires<Exception>(todos != null, "Lista de tarefas inválida");

            this._todos = new List<Todo>();

            foreach (var item in todos)
            {
                var todo = new Todo(item.Title, this.Id);
                this._todos.Add(todo);
            }
        }

        public void ClearTodos()
        {
            this._todos = new List<Todo>();
        }

        public void Inactivate()
        {
            this.IsActive = false;
        }

        public void Activate()
        {
            this.IsActive = true;
        }
    }
}
