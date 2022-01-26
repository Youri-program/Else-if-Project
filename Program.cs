
using System;

namespace OpdrachtTechnopolisYourivdMeulen
{
    class Program
    {
        static void Main(string[] args)
        {
            //                   ----Technopolis tarieven opdracht:  Youri van der Meulen----

            // Leeftijd? eerst vragen we wat de leeftijd is en daardoor wordt de ticketprijs beinvloed...
            Console.WriteLine("Wat is uw leeftijd?");
            string sAge = Console.ReadLine();
            int iAge = Int32.Parse(sAge);
            double dTicketprijs = 17.00;
            if (iAge < 4)
            {
                dTicketprijs -= 17.00;
                Console.WriteLine("Je bent gratis!");
            }
            else if (iAge > 3 && iAge < 12)
            {
                dTicketprijs -= 3.50;
            }
            else if (iAge > 64)
            {
                dTicketprijs -= 1.50;
            }
            else
            {
                dTicketprijs -= 0.00;
            }
            // Handicap? als je een handicap hebt wordt de ticketprijs ook wat goedkoper...
            Console.WriteLine("Heeft een bezoeker een handicap?");
            string sHandicap = Console.ReadLine().ToLower();
            if (sHandicap == "ja" && iAge > 4)
            {
                if (iAge > 3 && iAge < 12)
                {
                    dTicketprijs -= 0.50;
                }
                else if (iAge > 12 && iAge < 65)
                {
                    dTicketprijs -= 1.50;
                }
                else
                {
                    dTicketprijs -= 0.00;
                }
            }
            // Begeleiding nodig? iedereen kan begeleiding nodig hebben omdat ze in een rolstoel zitten of omdat je een handicap hebt, daarom vraag ik deze vraag aan iedereen.
            Console.WriteLine("Heeft u begeleiding nodig omdat u in een rolstoel zit of u een handicap heeft?");
            string sBegeleiding = Console.ReadLine().ToLower();
            if (sBegeleiding == "ja")
            {
                // Nu dat iemand een begeleider nodig heeft kunnen we vragen of hij/zij een rolstoelgebruiker is indien 'ja' dan is de begeleider hiervan gratis.
                // Indien 'nee' dan is er alleen gratis toegang voor een begeleider als er 2 bezoekers zijn met een handicap zonder rolstoelgebruik.
                Console.WriteLine("Bent u een rolstoelgebruiker en heeft u daarom een begeleider nodig?");
                string sRolstoelgebruiker = Console.ReadLine().ToLower();
                if (sRolstoelgebruiker == "ja")
                {
                    Console.WriteLine("Elke begeleider per rolstoelgebruiker is gratis!");
                }
                else if (sRolstoelgebruiker == "nee")
                {
                    Console.WriteLine("Is er per 2 bezoekers met een handicap zonder rolstoelgebruik 1 begeleider nodig?");
                    string sHandicapzonderrolstoel = Console.ReadLine().ToLower();
                    if (sHandicapzonderrolstoel == "ja")
                    {
                        Console.WriteLine("Elke begeleider per 2 bezoekers met een handicap is gratis!");
                    }
                }
            }
            // Leerkracht? deze vraag krijg je alleen als je 21 bent of boven de 21 bent t/m 65 jaar en 'nee' hebt ingevuld bij de handicap vraag en dus een leerkracht kunt zijn...
            if (iAge >= 21 && iAge <= 65 && sHandicap == "nee")
            {
                Console.WriteLine("Bent u een leerkracht en heeft u een geldige lerarenkaart?");
                string sLeerkracht = Console.ReadLine().ToLower();
                if (sLeerkracht == "ja")
                {
                    Console.WriteLine("U krijgt 50% korting en betaalt dus slechts €8,50!");
                    dTicketprijs /= 2;
                }
            }
            // Lidkaart? met de UiTPAS heb je recht op verminderd tarief.
            Console.WriteLine("Heeft u een UiTPAS en heeft u daarom recht op verminderd tarief?");
            string sUiTPAS = Console.ReadLine().ToLower();
            if (sUiTPAS == "ja")
            {
                // Als je in de gemeente Mechelen woont met een UiTPAS krijg je 80% korting.
                // Als je in een andere Vlaamse gemeente woont met een UiTPAS krijg je 50% korting.
                Console.WriteLine("Woont u in de gemeente Mechelen?");
                string sGemeenteMechelen = Console.ReadLine().ToLower();
                if (sGemeenteMechelen == "ja")
                {
                    dTicketprijs /= 5;
                }
                else if (sGemeenteMechelen == "nee")
                {
                    Console.WriteLine("Woont u in een andere Vlaamse gemeente?");
                    string sVlaamseGemeente = Console.ReadLine().ToLower();
                    if (sVlaamseGemeente == "ja")
                    {
                        dTicketprijs /= 2;
                    }
                }
            }
            // Groepsgrootte? wanneer je met een seniorengroep komt heb je ook voordelen... daarom vragen we eerst of u met een groep komt en later hoe groot deze groep is.
            // Deze vraag krijg je alleen als je in de seniorengroep valt...
            if (iAge >= 65)
            {
                Console.WriteLine("Komt u met een groep senioren?");
                string sGroepsenioren = Console.ReadLine().ToLower();
                if (sGroepsenioren == "ja")
                {
                    Console.WriteLine("Met hoeveel senioren komt u?");
                    string sAantalSenioren = Console.ReadLine();
                    int iAantalSenioren = Int32.Parse(sAantalSenioren);
                    if (iAantalSenioren < 15)
                    {
                        Console.WriteLine("Als u met minder dan 15 senioren komt betaal je het hele jaar door als 65-plusser slechts 16,50 euro voor je dagticket.");
                    }
                    else if (iAantalSenioren >= 15)
                    {
                        Console.WriteLine("U betaalt slechts 14,50 euro per persoon.");
                        dTicketprijs -= 1.00;
                    }
                }
            }
            // Uiteindelijke ticketprijs dat je moet betalen.
            Console.WriteLine($"U moet {dTicketprijs} euro betalen.");
        }
    }
}
