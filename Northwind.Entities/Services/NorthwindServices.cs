using Northwind.DAL.Entities;
using Northwind.BLL.DTO;
using Nortwind.DAL.Context;
using Nortwind.DAL.UnifOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Services
{
    public class NorthwindServices
    {

         UnitOfWork unitOfWork = new UnitOfWork(new DataBaseContext());

        /// <summary>
        /// Supplier Crud
        /// </summary>
        /// <returns></returns>
        public List<SupplierDto> getSupplierList()
        {
            List<SupplierDto> suppliers = new List<SupplierDto>();

            List<Suppliers> sups;

            sups = unitOfWork.SupplierRepository.GetAll();

            foreach (var item in sups)
            {
                SupplierDto supDto = new SupplierDto();
                supDto.SupplierID = item.SupplierID;
                supDto.Name = item.CompanyName;
                supDto.ContactName = item.ContactName;
                supDto.Title = item.ContactTitle;
                supDto.Country = item.Country;

                suppliers.Add(supDto);

            }

            return suppliers;
        }

        public bool AddSupplier(SupplierDto supplierDto)
        {
            Suppliers supplier = new Suppliers();
            supplier.CompanyName = supplierDto.Name;
            supplier.ContactName = supplierDto.ContactName;
            supplier.ContactTitle = supplierDto.Title;
            supplier.Country = supplierDto.Country;
          

            unitOfWork.SupplierRepository.Add(supplier);
            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateSupplier(SupplierDto supplierDto)
        {

            Suppliers supplier = unitOfWork.SupplierRepository.GetById(supplierDto.SupplierID);

            supplier.CompanyName = supplierDto.Name;
            supplier.ContactName = supplierDto.ContactName;
            supplier.Country = supplierDto.Country;
            supplier.ContactTitle = supplierDto.Title;
            supplier.Country = supplierDto.Country;

            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveSupplier(SupplierDto supplierDto)
        {
            unitOfWork.SupplierRepository.Remove(supplierDto.SupplierID);

            int result = unitOfWork.Complete();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Employee Crud
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDto> getEmployeeList()
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            List<Employees> emps;

            emps = unitOfWork.EmployeeRepository.GetAll();

            foreach (var item in emps)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.EmployeeID = item.EmployeeID;
                employeeDto.FirstName = item.FirstName;
                employeeDto.LastName = item.LastName;
                employeeDto.Title = item.Title;


                employees.Add(employeeDto);

            }

            return employees;
        
    }
        public bool AddEmployee(EmployeeDto employeeDto)
        {
            Employees emplyee = new Employees();
            emplyee.FirstName = employeeDto.FirstName;
            emplyee.LastName = employeeDto.LastName;
            emplyee.Title = employeeDto.Title;

            unitOfWork.EmployeeRepository.Add(emplyee);
            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateEmployee(EmployeeDto employeeDto)
        {

            Employees employee = unitOfWork.EmployeeRepository.GetById(employeeDto.EmployeeID);

            //employee.EmployeeID = employeeDto.EmployeeID;
            employee.LastName = employeeDto.LastName;
            employee.FirstName = employeeDto.FirstName;
            employee.Title = employeeDto.Title;

            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveEmployee(EmployeeDto employeeDto)
        {
            unitOfWork.EmployeeRepository.Remove(employeeDto.EmployeeID);

            int result = unitOfWork.Complete();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Customer 
        /// </summary>
        /// <returns></returns>
        public List<CustomerDto> getCustomerList()
        {
            List<CustomerDto> customer = new List<CustomerDto>();

            List<Customers> cstmr;

            cstmr = unitOfWork.CustomerRepository.GetAll();

            foreach (var item in cstmr)
            {
                CustomerDto customerDto = new CustomerDto();
                customerDto.CustomerId = item.CustomerID;
                customerDto.CompanyName = item.CompanyName;
                customerDto.ContactName = item.ContactName;
                customerDto.City = item.City;

                customer.Add(customerDto);

            }
            return customer;
        }

        public bool AddCustomer(CustomerDto customerDto)
        {
            Customers customer;
            customer = new Customers();
            customer.CustomerID = customerDto.CustomerId;
            customer.CompanyName = customerDto.CompanyName;
            customer.ContactName = customerDto.ContactName;
            customer.City = customerDto.City;
       

            unitOfWork.CustomerRepository.Add(customer);
            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool RemoveCustomer(CustomerDto customerDto)
        {
            unitOfWork.CustomerRepository.RemoveString(customerDto.CustomerId);

            int result = unitOfWork.Complete();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCustomer(CustomerDto customerDto)
        {

            Customers customer = unitOfWork.CustomerRepository.GetByIdString(customerDto.CustomerId);

            customer.CustomerID = customerDto.CustomerId;
            customer.CompanyName = customerDto.CompanyName;
            customer.ContactName = customerDto.ContactName;
            customer.City = customerDto.City;

            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Şehre göre arama
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<CustomerDto> FilterCustomerByCity(string city)
        {
            List<CustomerDto> customerDtoList = new List<CustomerDto>();
            List<Customers> cstmr = unitOfWork.CustomerRepository.FilterByCity(c => c.City == city);

            foreach (var item in cstmr)
            {
                CustomerDto customerDto = new CustomerDto();
                customerDto.CustomerId = item.CustomerID;
                customerDto.CompanyName = item.CompanyName;
                customerDto.ContactName = item.ContactName;
                customerDto.City = item.City;


                customerDtoList.Add(customerDto);
            }

            return customerDtoList;
        }

        /// <summary>
        /// Product
        /// </summary>
        /// <returns></returns>
        public List<ProductDto> getProductList()
        {
            List<ProductDto> productDtos = new List<ProductDto>();

            List<Products> prdcts;

            prdcts = unitOfWork.ProductRepository.GetAll();

            foreach (var item in prdcts)
            {
                ProductDto prdctDto = new ProductDto();
                prdctDto.UrunAdi = item.ProductName;
                prdctDto.Stok = item.UnitsInStock;
                prdctDto.Fiyat = item.UnitPrice;


                productDtos.Add(prdctDto);

            }

            return productDtos;
        }

        public bool AddProduct(ProductDto productDto)
        {
            Products product;
            product = new Products();
            product.ProductName = productDto.UrunAdi;
            product.UnitPrice = productDto.Fiyat.Value;
            product.UnitsInStock = (short)productDto.Stok.Value;
          

            unitOfWork.ProductRepository.Add(product);
            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveProduct(ProductDto productDto)
        {
            unitOfWork.ProductRepository.Remove(productDto.ProductID);

            int result = unitOfWork.Complete();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(ProductDto productDto)
        {

            Products product = unitOfWork.ProductRepository.GetById(productDto.ProductID);

             
            product.ProductName = productDto.UrunAdi;
            product.UnitPrice = Convert.ToDecimal(productDto.Fiyat);
            product.UnitsInStock = (short)productDto.Stok;
          

            int result = unitOfWork.Complete();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

          

        }

        public List<ProductDto> FilterProductByUnitPrice(decimal price)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();
            List<Products> prdct = unitOfWork.ProductRepository.TopUnitPrice(c => c.UnitPrice > price);

            foreach (var item in prdct)
            {
                ProductDto productDto = new ProductDto();
                productDto.ProductID = item.ProductID;
                productDto.UrunAdi = item.ProductName;
                productDto.Stok = item.UnitsInStock;
                productDto.Fiyat = item.UnitPrice;

                productDtoList.Add(productDto);
            }

            return productDtoList;
        }



    }
}
