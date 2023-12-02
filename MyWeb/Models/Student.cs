using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MyWeb.Models
{
    public class Student
    {
        private readonly ILazyLoader? lazyLoader;
        public Student() { }
        public Student(ILazyLoader loader)
        {
            lazyLoader = loader;
        }
        public Bill? bill;
        public Bill? Bill { get => lazyLoader?.Load(this, ref bill); set => bill = value; }
    }
}
