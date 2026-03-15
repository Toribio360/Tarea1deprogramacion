



try { 

    Console.WriteLine("Welcomecto to the agenda");


    //names, lastnames, addresses, telephones, emails, ages, bestfriend
    bool runing = true;
    List<int> ids = new List<int>();
    Dictionary<int, string> names = new Dictionary<int, string>();
    Dictionary<int, string> lastnames = new Dictionary<int, string>();
    Dictionary<int, string> addresses = new Dictionary<int, string>();
    Dictionary<int, string> telephones = new Dictionary<int, string>();
    Dictionary<int, string> emails = new Dictionary<int, string>();
    Dictionary<int, int> ages = new Dictionary<int, int>();
    Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


    while (runing)
    {
        Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
        Console.WriteLine("Digite el número de la opción deseada");
        int typeOption = 0;
        bool validOption = false;

        while (!validOption)
        {
            try
            {
                typeOption = Convert.ToInt32(Console.ReadLine());
                validOption = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Digite un número válido según las opciones.");
            }
        }


        switch (typeOption)
        {
            case 1:
                {
                    //Console.WriteLine("Digite el nombre de la persona");
                    //string name = Console.ReadLine();
                    //Console.WriteLine("Digite el apellido de la persona");
                    //string lastname = Console.ReadLine();
                    //Console.WriteLine("Digite la dirección");
                    //string address = Console.ReadLine();
                    //Console.WriteLine("Digite el telefono de la persona");
                    //string phone = Console.ReadLine();
                    //Console.WriteLine("Digite el email de la persona");
                    //string email = Console.ReadLine();
                    //Console.WriteLine("Digite la edad de la persona en números");
                    //int age = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                    ////var temp = Convert.ToInt32(Console.ReadLine());
                    ////bool isBestFriend;
                    ////if (temp == 1)
                    ////{ isBestFriend = true; }
                    ////else
                    ////{ isBestFriend = false; }
                    //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                    //var id = ids.Count + 1;
                    //ids.Add(id);
                    //names.Add(id, name);
                    //lastnames.Add(id, lastname);
                    //addresses.Add(id, address);
                    //telephones.Add(id, phone);
                    //emails.Add(id, email);
                    //ages.Add(id, age);
                    //bestFriends.Add(id, isBestFriend);


             
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

                }
                break;
            case 2: //extract this to a method
                {
                    Console.WriteLine($"id  Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                    Console.WriteLine($"____________________________________________________________________________________________________________________________");
                    foreach (var id in ids)
                    {
                        var isBestFriend = bestFriends[id];

                        //string isBestFriendStr;

                        //if (isBestFriend == true)
                        //{
                        //    isBestFriendStr = "Si";
                        //}
                        //else {
                        //    isBestFriendStr = "No";
                        //}

                        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                        Console.WriteLine($" {id}   {names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                    }

                }
                break;
            case 3: //search
                {

                    Console.WriteLine(" Digite el nombre del contacto que desea buscar. ");
                string searchname = Console.ReadLine();

                    bool found = false;

                    foreach (var id in ids )
                    {
                        if (names[id].ToLower () == searchname.ToLower())
                        {

                            string isBestFriendStr = bestFriends[id] ? "Si" : "No";

                            Console.WriteLine($"Nombre: {names[id]}");
                            Console.WriteLine($"Apellido: {lastnames[id]}");
                            Console.WriteLine($"Dirección: {addresses[id]}");
                            Console.WriteLine($"Telefono: {telephones[id]}");
                            Console.WriteLine($"Email: {emails[id]}");
                            Console.WriteLine($"Edad: {ages[id]}");
                            Console.WriteLine($"Mejor Amigo: {isBestFriendStr}");
                            Console.WriteLine("__________________________________");


                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Contacto no encontrado.");
                    }
      

                }
                
                break;
            case 4: //modify
                {
                    Console.WriteLine("Favor de ingresar el id del contacto que desea modificar.");
                 int modify = Convert.ToInt32( Console.ReadLine() );
                
               
                    if (ids.Contains(modify))
                    {
                       
                         
                        Console.WriteLine($"Digite el nuevo nombre del contacto: {names[modify]}");
                        names[modify] = Console.ReadLine();
                        Console.WriteLine("Digite el apellido de la persona");
                        lastnames[modify] = Console.ReadLine();
                        Console.WriteLine("Digite la dirección");
                        addresses[modify]= Console.ReadLine();
                        Console.WriteLine("Digite el telefono de la persona");
                        telephones[modify] = Console.ReadLine();
                        Console.WriteLine("Digite el email de la persona");
                        emails[modify] = Console.ReadLine();
                        Console.WriteLine("Por favor digite la nueva edad del contacto");
                        ages[modify] = Convert.ToInt32( Console.ReadLine() );
                        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                        bestFriends[modify] = Console.ReadLine() == "1";
                        Console.WriteLine("Contacto modificado con exito");

                    } else
                    {
                        Console.WriteLine("Contacto no encontrado");
                    }



                }
                break;
            case 5: //delete
                {
                    Console.WriteLine("Digiste el id del conctato que desea eliminar.");
                    int deleteid = Convert.ToInt32( Console.ReadLine() );

                    if (ids.Contains(deleteid))
                    {
                        ids.Remove (deleteid);
                        names.Remove(deleteid);
                        lastnames.Remove(deleteid);
                        addresses.Remove(deleteid);
                        telephones.Remove(deleteid);
                        emails.Remove(deleteid);
                        ages.Remove(deleteid);
                        bestFriends.Remove(deleteid);

                        Console.WriteLine("Contacto eliminado correctamente.");

                    }
                    else
                    {
                        Console.WriteLine("El contacto no existe.");
                    }



                }
                break;
            case 6:
                runing = false;
                break;
            default:
                Console.WriteLine("Tu eres o te haces el idiota?");
                break;
        }
    }


    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
     

    {
        
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();

        int age = 0;
        bool validAge = false;

        Console.WriteLine("Digite la edad de la persona en números");
        while (!validAge)
        {
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                validAge = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Debe escribir la edad en números.");
            }
        }

        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");



        bool isBestFriend = false;
        bool validBestFriend = false;

        while (!validBestFriend)
        {
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                isBestFriend = option == 1;
                validBestFriend = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Escriba 1 para Si o 2 para No.");
            }
        }


        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);


}
}
catch (Exception)
{
    Console.WriteLine("Ocurrió un error inesperado.");
}


Console.ReadKey();