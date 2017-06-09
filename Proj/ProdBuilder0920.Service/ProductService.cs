using System;
using ProdBuilder0920.Domain;
using System.Collections.Generic;
using ProdBuilder0920.Domain.ViewModels;

namespace ProdBuilder0920.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductServiceRepository _repository;

        public ProductService(IProductServiceRepository repository)
        {
            _repository = repository;
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAllOrders();
        }

        public List<Order> GetOrders(string username)
        {
            return _repository.GetOrders(username);
        }

        public Order GetOrder(int id)
        {
            return _repository.GetOrder(id);
        }

        public void UpdateOrderStatus(Order model)
        {
            _repository.UpdateOrderStatus(model);
        }    

        public void WriteOrder(List<Part> cartList, int id, string user, int packetPrice)
        {
            _repository.WriteOrder(cartList,id,user,packetPrice);
        }

        public DateTime LatestDate(List<Part> cartList)
        {
           return _repository.LatestDate(cartList);
        }

        public string GetProdCode(List<Part> cartList)
        {
           return _repository.GetProdCode(cartList);
        }

        public int GetPriceForParts(List<Part> cartList) 
        {
           return _repository.GetPriceForParts(cartList);
        }

        public List<PackageSeries> GetAllPackageSeries()
        {
            return _repository.GetAllPackageSeries();
        }

        public PackageSeries GetAPackageSeries(int id)
        {
            return _repository.GetAPackageSeries(id);
        }

        public void UpdateSeries(PackageSeries model)
        {
            _repository.UpdateSeries(model);
        }

        public void UpdatePackage(Package model)
        {
            _repository.UpdatePackage(model);
        }

        public void UpdatePArtType(PartType model)
        {
            _repository.UpdatePArtType(model);
        }

        public void UpdatePart(Part model)
        {
           _repository.UpdatePart(model);
        }


        public List<Package> GetAllPackages_()
        {
           return _repository.GetAllPackages_();
        }

        public List<Package> GetAllPackages(int id)
        {
            return _repository.GetAllPackages(id);
        }

        public Package GetAPackage(int id)
        {
            return _repository.GetAPackage(id);
        }

        public List<Part> GetAllParts()
        {
           return _repository.GetAllParts();
        }

        public List<PartType> GetAllPartTypes()
        {
            return _repository.GetAllPartTypes();
        }

     
        public PartType GetAPartType(int id)
        {
           return _repository.GetAPartType(id);

        }
        
        public List<PartType> GetPartTypes(int id)
        {
           return _repository.GetPartTypes(id);
        }

        public List<Part> GetParts(int id)
        {
           return _repository.GetParts(id);
        }

        public Part GetPart(int id)
        {
            return _repository.GetPart(id);
        }

        public List<PartType> GetParttypesAndParts(int id)
        {
           return _repository.GetParttypesAndParts(id);
        }

        public Part GetPartTypeAndPart(int id)
        {
           return _repository.GetPartTypeAndPart(id);
        }

        public bool GetCartStatus(List<Part> list, Part parttype)  //returns true if exists
        {
           return _repository.GetCartStatus(list, parttype);
        }                                                     

        public void AddPackageSeries(PackageSeries packageseries)
        {
            _repository.AddPackageSeries(packageseries);
        }

        public void AddPackage(AdminAddPackageViewModel model)
        {
           _repository.AddPackage(model);
        }

        public void AddPartType(AdminAddParttypwViewModel model)
        {
            _repository.AddPartType(model);
        }

        public void AddPart(Part model)
        {
            _repository.AddPart(model);
        }

        public void PsDeletePart(int partid)
        {
           _repository.PsDeletePart(partid);
        }

        public void PSsDeletePartType(int id)
        {
            _repository.PSsDeletePartType(id);
        }

        public void PSsDeletePackage(int id)
        {
           _repository.PSsDeletePackage(id);
        }

        public void PSsDeletePackageSeries(int id)
        {
           _repository.PSsDeletePackageSeries(id);
        }

    }
}
