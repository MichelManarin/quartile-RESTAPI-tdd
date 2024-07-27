using Stores.API.Models;
using Stores.API.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Stores.UnitTests.Helpers
{
    public static class TestDataGenerator
    {
        public static CompanyViewModel CreateFakeCompanyViewModel()
        {
            return new CompanyViewModel
            {
                Name = "Fake Company",
                Address = CreateFakeAddressViewModel()
            };
        }

        public static AddressViewModel CreateFakeAddressViewModel()
        {
            return new AddressViewModel
            {
                Street = "fake street",
                City = "fake city",
                State = "fake state",
                Country = "fake country",
                ZipCode = "89040-115"
            };
        }

        public static Address CreateFakeAddressModel()
        {
            return new Address("fake street", "fake city", "fake state", "fake country", "89040-115");
        }

        public static Store CreateFakeStoreModel()
        {
            return new Store(1, "Any name", CreateFakeAddressModel(), "Any phone number");
        }
        public static Company CreateFakeCompanyModel()
        {
            return new Company("Any compant", CreateFakeAddressModel());
        }

        public static int GetFakeCompanyId()
        {
            return 7;
        }

        public static StoreViewModel CreateFakeStoreViewModel()
        {
            return new StoreViewModel
            {
                Id = 1,
                Name = "Fake Store",
                PhoneNumber = "Fake Number",
                Address = CreateFakeAddressViewModel(),
            };
        }


    }
}
