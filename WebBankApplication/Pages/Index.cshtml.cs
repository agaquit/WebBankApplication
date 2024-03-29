﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBankApplication.BankApplication;
using WebBankApplication.Services;
using WebBankApplication.ViewModels;

namespace WebBankApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public IndexModel(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        public HomeViewModel ViewModel { get; set; }

        public void OnGet()
        {
            ViewModel = new HomeViewModel
            {
                TotalCustomers = _customerService.GetTotalCustomers(),
                TotalAccounts = _accountService.GetAllAccounts().Count(),
                TotalBalance = _accountService.GetTotalBalance()
            };
        }
    }
}