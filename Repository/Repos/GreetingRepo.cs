using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GreetingRepo
    {
        public List<GreetingPoco> _Greetings = new List<GreetingPoco>();
        public List<GreetingPoco> GetList()
        {
            return _Greetings;
        }
        public void AddGreeting(GreetingPoco Greeting)
        {
            _Greetings.Add(Greeting);
            UpdateName(Greeting.firstname, 1, _Greetings.Count - 1);
            UpdateName(Greeting.lastname, 2, _Greetings.Count - 1);
            UpdateStatus(_Greetings.Count - 1, _Greetings[_Greetings.Count - 1].status);
        }
        public void RemoveGreeting(int id)
        {
            _Greetings.RemoveAt(id);
        }
        public void UpdateName(string nombre, int order, int id)
        {
            if (order == 1)
            {
                _Greetings[id].firstname = nombre;
            }
            else if (order == 2)
            {
                _Greetings[id].lastname = nombre;
            }
            _Greetings[id].fullname = _Greetings[id].firstname + " " + _Greetings[id].lastname;
        }
        public void UpdateStatus(int id, int stat)
        {
            _Greetings[id].status = stat;
            switch (stat)
            {
                case 1:
                    _Greetings[id].type = "Past";
                    _Greetings[id].email = "It's been a long time since we've heard from you, we want you back.";
                    break;
                case 2:
                    _Greetings[id].type = "Current";
                    _Greetings[id].email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case 3:
                    _Greetings[id].type = "Potential";
                    _Greetings[id].email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                default:
                    break;
            }
        }
    }
}
