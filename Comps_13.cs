//Project Computer v.5
//static members and methods

using System;
using System.Collections.Generic;

namespace OOP_in_Csharp
{
//----------class Abstract--------------------
    public abstract class Working
    {
        public Working(string name, string make){
            _name = name;
            _make = make;
        }
        
        protected string _name;
        protected string _make;
        public abstract void StartWork();
        public abstract void ShutDown();
    }
    
//----------class Computer--------------------
    public class Computer : Working
    {
        public Computer(string name, string make, string os, bool switched) : base(name, make)
        {
            this.Name = name;
            this.Make = make;
            this.OperatingSystem = os;
            this.SwitchedOn = switched;
            compCounter++;
        }

        /*public Computer()
        {
            compCounter++;
        }
        */
        
        // private member variables
        //private string _name;
        private string _ipadress;
        private bool _switchedOn = false;
        //private string _make;
        private string _operatingSystem;

        protected static int compCounter = 0; //counts comps in the network
        protected static int switchedCounter = 0; //counts the state of the computers
        protected static int compInNet = 10; //counts 

        public static int CountComps()
        {
            return compCounter;
        }

        public static int CountSwitched()
        {
            return switchedCounter;
        }

        public override void StartWork()
        {
            if (SwitchedOn == false)
            {
                this.SwitchedOn = true;
                switchedCounter++;
            }
            this.Ipaddress = GetIpAddress();
            Console.WriteLine("the computer {0} is starting", this.Ipaddress);
        }

        public string GetIpAddress()
        {
            string address = "10.0.0." + (++compInNet).ToString();
            return address;
        }

        public override void ShutDown()
        {
            this.SwitchedOn = false;
            switchedCounter--;
            Console.WriteLine("the computer {0} is shutDown!", this.Ipaddress);
        }

        public string IsSwitched()
        {
            if (this.SwitchedOn)
            {
                return "switched ON";
            }
            else
            {
                return "switched OFF";
            }
        }

        public void ComputerPing(List<Computer> net, string consoleIp)
        {
            bool found = false;
            foreach (Computer result in net)
            {
                //Console.Write(network[1]);
                if (result.Ipaddress == consoleIp)
                {
                    found = true;
                }
            }
            if(found)
            Console.WriteLine("You have ping with the computer");
            else
                Console.WriteLine("You don't have ping with the computer");
        }

        // public properties
        public string Ipaddress
        {
            get
            {
                return _ipadress;
            }
            set
            {
                _ipadress = value;
            }
        }
        
         public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = value;
            }
        }

        public string OperatingSystem
        {
            get
            {
                return _operatingSystem;
            }
            set
            {
                _operatingSystem = value;
            }
        }

        public bool SwitchedOn
        {
            get
            {
                return _switchedOn;
            }
            set
            {
                _switchedOn = value;
            }
        }
        
        public static void ShowComputers (List<Computer> net)
        {
            foreach (Computer comp in net) 
			{
				if (comp.SwitchedOn) 
				{
					Type type = comp.GetType();
					string stringType = type.ToString ();
					Console.Write("{0}\t{1}\t{2}\t\t{3}", comp.Name, comp.Ipaddress, comp.OperatingSystem, comp.Make);
					int pos = stringType.IndexOf('.');
					//Console.Write(stringType.Substring(pos+1,4));
					
					if(stringType.Substring(pos+1,4) == "Serv")
					{
					    Server serv = (Server) comp;
						System.Console.WriteLine("\t{0}", serv.Destination);
					}
					else
					Console.WriteLine();	
				}   
			
			}	    
        }
        
        public static void PingToComputer (List<Computer> net, Computer pingFrom, string pingTo)
        {
            Random rnd = new Random();
    		double answer;
    		Computer myComp = pingFrom;
    		bool found = false;	
    		Console.WriteLine("\nTrying to ping from the machine{0}({1}) to {2}.", myComp.Name, myComp.Ipaddress, pingTo);
    		Console.WriteLine("--------------------------------------------------------------------");
    		foreach (Computer comp in net) 			 	
    		{
    			if ((pingTo == comp.Ipaddress) && (comp.SwitchedOn == true)) 
    			{
    				found = true;
    				break;
    			} 
    		} // the end of the loop
    		if (found) 
    		{ 
    			for (int i = 5; i < 15; i++) 
    			{ 
    				answer = (float)(rnd.Next(1, 100))/100;
    				Console.WriteLine ("64 bytes from {0} icmp_seq={1} ttl=64 time={2} ms", myComp.Ipaddress, i.ToString(), answer.ToString());
    			}
    		}	
    		else
    		{					
    			Console.WriteLine ("Adress {0} not found !!! ", pingTo );
    		} 
        }
    }
    
//--------------------------------------
    public class Server : Computer
	{
		public Server (string name, string make, string os, bool state, string dest, string ip) : base(name, make, os, state)
		{			
			this.Destination = dest;
            this.Ipaddress = ip;
		}

		// private member variables
		protected string _destination;

		// public properties
		public string Destination
		{
			get { return _destination;  }
			set { _destination = value; }
		}
		
		public override void ShutDown() 
		{   
		    Console.WriteLine("************* !!! **************** ");
		    Console.Write("You want to shut dowm this server. Are you sure ? (YES/n): ");
			
			
			string confirm = Console.ReadLine();
			if (confirm == "YES") 
			{
    			this.SwitchedOn = false; 
    			switchedCounter--;
    			Console.WriteLine("The comp {0} is shuting down !!!", this.Ipaddress);
			}
			
		}
		
		public override void StartWork()
        {
            this.SwitchedOn = true;
            switchedCounter++;
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }
	}
//----------class Computer--------------------
    class Program
    {
        public static void Main(string[] args)
        {
            //list of Arrays
            List<Computer> network = new List<Computer>();

            //Creating the object
            Server servidor = new Server("servidor", "Dell", "Windows", false, "WEB Server", "10.0.0.10");
            Server servidor2 = new Server("servidor2", "Mac", "Linux", false, "WEB Server", "10.0.0.11");
            Server servidor3 = new Server("servidor3", "Acer", "Windows", false, "WEB Server", "10.0.0.12");
            Computer myFirstComp = new Computer("myFirstComp", "Lenovo", "Linux", false);
            Computer mySecondComp = new Computer("mySecondComp", "Toshiba", "Windows", false);
            Computer myThirdComp = new Computer("myThirdComp", "Asus", "Linux", false);

            //Add the computer to the Array
            network.Add(servidor);
            network.Add(servidor2);
            network.Add(servidor3);
            network.Add(myFirstComp);
            network.Add(mySecondComp);
            network.Add(myThirdComp);
            
            Console.WriteLine("--------------------------------------");
            
            //Swiching On the Computers
            for(int i=0; i<network.Count; i++)
            {
                network[i].StartWork();
            }
            
            Console.WriteLine("--------------------------------------");
            
            int compsInNetwork = Computer.CountComps();
            int stateOfComputer = Computer.CountSwitched();
            Console.WriteLine("We have {0} computers in our network.",
                   compsInNetwork);
            Console.WriteLine("We have {0} computer connected", stateOfComputer);
            
            Console.WriteLine("--------------------------------------");
            
            //Searching the IP
            Console.WriteLine("Write the IP to search: ");
            string searchIp= Console.ReadLine();
            
            //iterating over the List network
            foreach (Computer comp in network) 
			{
				if (comp.SwitchedOn) 
				{
					Console.Write("{0}\t{1}\t\t{2}\t", comp.Ipaddress, comp.OperatingSystem, comp.Make);
					Type type = comp.GetType();
					string stringType = type.ToString ();
					int pos = stringType.IndexOf('.');
					Console.Write(stringType.Substring(pos+1,4));

					if(stringType.Substring(pos+1,4) == "Serv")
					{
						System.Console.WriteLine("\t{0}", servidor.Destination);
					}
					else
					Console.WriteLine();	
				

					//Console.WriteLine(comp.GetType());
				}     
			}	
            
            Console.WriteLine("--------------------------------------");
            myFirstComp.ComputerPing(network, searchIp);
            mySecondComp.ShutDown();
            servidor.ShutDown();
            
            //iterating over the list network		
			foreach (Computer comp in network) 
			{
				if (comp.SwitchedOn) 
				{
					Console.WriteLine("{0}\t{1}\t\t{2}", comp.Ipaddress, comp.OperatingSystem, comp.Make);
				}     
			}	    
			Console.WriteLine ("--------------------------------------------------------------------\n"); 	    
            
            //Test of ping to other computers

			Random rnd = new Random();
			double answer;

			Computer myComp = myFirstComp;
			String pingTo = "10.0.0.14";

			bool found = false;	
			foreach (Computer comp in network) 			 	
				//this can be encapsulated
			{
				if ((pingTo == comp.Ipaddress) && (comp.SwitchedOn == true)) 
				{
					found = true;
					break;
				} 
			} // the end of the loop


			if (found) 

			{ 
				for (int i = 5; i < 15; i++) 
				{ 
					answer = (float)(rnd.Next(1, 100))/100;
					Console.WriteLine ("64 bytes from {0} icmp_seq={1} ttl=64 time={2} ms", myComp.Ipaddress, i.ToString(), answer.ToString());
				}
			}	
			else
			{					
				Console.WriteLine ("Adress {0} not found !!! ", pingTo );
			}
			//the end of pinging
			
			Console.WriteLine("--------------------------------------");
			
            //Information about the computers
            Console.WriteLine("comp no.1 ({0}) with {1} installed. " +
                   "It's IP address is {2}. {3}",
                   myComp.Make, myComp.OperatingSystem, myComp.Ipaddress, myComp.IsSwitched());

            Console.WriteLine("comp no.2 ({0}) with {1} installed. " +
                   "It's IP address is {2}. {3}",
                   mySecondComp.Make, mySecondComp.OperatingSystem, mySecondComp.Ipaddress, mySecondComp.IsSwitched());
                   
            Console.WriteLine("comp no.3 ({0}) with {1} installed. " +
                   "It's IP address is {2}. {3}",
                   myThirdComp.Make, myThirdComp.OperatingSystem, myThirdComp.Ipaddress, myThirdComp.IsSwitched());      
                   
            Console.WriteLine("--------------------------------------");
            
            Computer.ShowComputers(network);
            
            Console.WriteLine("--------------------------------------");
            
            //Computer.PingToComputer(network, myComp, "10.0.0.14");
            
            Console.Read();

        }
    }
}





