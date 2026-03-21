class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Contact(int id, string name, string phone, string email, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }
}

class Agenda
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1;

    public void AddContact()
    {
        Console.WriteLine("\n--- Agregar Contacto ---");

        Console.Write("Nombre: ");
        string name = Console.ReadLine();

        Console.Write("Teléfono: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Dirección: ");
        string address = Console.ReadLine();

        Contact contact = new Contact(nextId++, name, phone, email, address);
        contacts.Add(contact);

        Console.WriteLine(" Contacto agregado correctamente\n");
    }

    public void ViewContacts()
    {
        Console.WriteLine("\n--- Lista de Contactos ---");

        if (contacts.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        Console.WriteLine("ID   Nombre   Teléfono   Email   Dirección");

        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.Id}   {c.Name}   {c.Phone}   {c.Email}   {c.Address}");
        }
    }

    private Contact FindById(int id)
    {
        return contacts.FirstOrDefault(c => c.Id == id);
    }

    public void SearchContact()
    {
        Console.Write("\nIngrese ID a buscar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var c = FindById(id);

        if (c != null)
        {
            Console.WriteLine("\n--- Contacto Encontrado ---");
            Console.WriteLine($"Nombre: {c.Name}");
            Console.WriteLine($"Teléfono: {c.Phone}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine($"Dirección: {c.Address}");
        }
        else
        {
            Console.WriteLine(" Contacto no encontrado");
        }
    }

    public void EditContact()
    {
        ViewContacts();

        Console.Write("\nIngrese ID a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var contact = FindById(id);

        if (contact == null)
        {
            Console.WriteLine(" Contacto no encontrado");
            return;
        }

        Console.Write($"Nombre actual ({contact.Name}): ");
        contact.Name = Console.ReadLine();

        Console.Write($"Teléfono actual ({contact.Phone}): ");
        contact.Phone = Console.ReadLine();

        Console.Write($"Email actual ({contact.Email}): ");
        contact.Email = Console.ReadLine();

        Console.Write($"Dirección actual ({contact.Address}): ");
        contact.Address = Console.ReadLine();

        Console.WriteLine("Contacto actualizado");
    }

    public void DeleteContact()
    {
        ViewContacts();

        Console.Write("\nIngrese ID a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var contact = FindById(id);

        if (contact == null)
        {
            Console.WriteLine(" Contacto no encontrado");
            return;
        }

        Console.Write("¿Seguro que desea eliminar? (1 = Sí, 2 = No): ");
        int opcion = Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contacto eliminado");
        }
        else
        {
            Console.WriteLine("Cancelado");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        bool running = true;

        Console.WriteLine(" Mi Agenda Perron");
        Console.WriteLine("Bienvenido a tu lista de contactos\n");

        while (running)
        {
            Console.WriteLine("\n1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Editar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");

            Console.Write("Elige una opción: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(" Entrada inválida");
                continue;
            }

            switch (choice)
            {
                case 1:
                    agenda.AddContact();
                    break;
                case 2:
                    agenda.ViewContacts();
                    break;
                case 3:
                    agenda.SearchContact();
                    break;
                case 4:
                    agenda.EditContact();
                    break;
                case 5:
                    agenda.DeleteContact();
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine(" Opción no válida");
                    break;
            }
        }

        Console.WriteLine(" Gracias por usar la agenda");
    }
}
