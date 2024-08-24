using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using CodeFirstGabrielCampos.Entities;
using Microsoft.Extensions.Options;
using System.Security.Principal;

class Program
{
    private static void insertData(EFCoreDbContext context) 
    {
        try
        {
            var customer = new Customer
            {
                Name = "Julian",
                Email = "loki@gmail.com"
            };

            var bank = new Bank
            {
                BankName = "Sample Joki",
                Address = "Hilinois Sample St"
            };



            context.Banks.Add(bank);

            //Now the Entity State will be in Added State
            Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(bank).State}");

            context.SaveChanges();

            //Now the Entity State will change from Added State to Unchanged State
            Console.WriteLine($"After SaveChanges Entity State:{context.Entry(bank).State}");

            var account = new Account
            {
                AccountNumber = "MK902",
                Customer = customer,
                Bank = bank
            };

            context.Accounts.Add(account);

            //Now the Entity State will be in Added State
            Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(account).State}");

            context.SaveChanges();

            //Now the Entity State will change from Added State to Unchanged State
            Console.WriteLine($"After SaveChanges Entity State:{context.Entry(account).State}");

            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void updateData(EFCoreDbContext context) 
    {
        try
        {
            //Fetch the Student from database whose Id = 2
            var account = context.Accounts.Find(2);

            if (account != null) 
            {

                account.AccountNumber = "MP231";
                account.Balance = 699;

                context.SaveChanges();

                Console.WriteLine("account Updated Successfully...");
            } 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); ;
        }
    }

    private static void deleteData(EFCoreDbContext context) 
    {
        try
        {
            var account = context.Accounts.Find(2);

            if (account != null)
            {
                // REMOVE ACCOUNT
                context.Accounts.Remove(account);

                context.SaveChanges();
            }
        }
        catch (Exception e) 
        { 
        } 
    }
    static void Main(string[] args)
    {
        using var context = new EFCoreDbContext();

        deleteData(context);
    }
}
