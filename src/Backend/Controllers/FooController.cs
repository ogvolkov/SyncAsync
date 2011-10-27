using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Contracts;

namespace Web.Controllers
{
    /// <summary>
    /// Controller providing Foo services
    /// </summary>
    public class FooController: Controller, IFooService
    {
        private readonly IEnumerable<Foo> _foos = new[]
                        {
                            new Foo {Id = 1, Name = "Jimi"},
                            new Foo {Id = 2, Name = "Ritchie"},
                            new Foo {Id = 3, Name = "Yngwie"}
                        };

        public FooController()
        {
            // this is the part that converts our DTOs into serialized HTTP response consumable by client
            ActionInvoker = new ServiceActionInvoker();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public FutureResult<Foo> GetOne(int id)
        {   
            // simulate some database crunching
            Thread.Sleep(500);

            // just return you Foo, action invoker will do the magic!
            return _foos.FirstOrDefault(it => it.Id == id);        
        }       
    }
}
