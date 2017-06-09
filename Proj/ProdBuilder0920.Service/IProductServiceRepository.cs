using ProdBuilder0920.Domain;
using System;
using System.Collections.Generic;
using ProdBuilder0920.Domain.ViewModels;

namespace ProdBuilder0920.Service
{
    public interface IProductServiceRepository
    {
        List<Order> GetAllOrders();
        List<Order> GetOrders(string username);
        Order GetOrder(int id);
        void UpdateOrderStatus(Order model);
        void WriteOrder(List<Part> cartList, int id, string user, int packetPrice);
        DateTime LatestDate(List<Part> cartList);
        string GetProdCode(List<Part> cartList);
        int GetPriceForParts(List<Part> cartList);
        List<PackageSeries> GetAllPackageSeries();
        PackageSeries GetAPackageSeries(int id);
        void UpdateSeries(PackageSeries model);
        void UpdatePackage(Package model);
        void UpdatePArtType(PartType model);
        void UpdatePart(Part model);
        List<Package> GetAllPackages_();
        List<Package> GetAllPackages(int id);
        Package GetAPackage(int id);
        List<Part> GetAllParts();
        List<PartType> GetAllPartTypes();
        PartType GetAPartType(int id);
        List<PartType> GetPartTypes(int id);
        List<Part> GetParts(int id);
        Part GetPart(int id);
        List<PartType> GetParttypesAndParts(int id);
        Part GetPartTypeAndPart(int id);
        bool GetCartStatus(List<Part> list, Part parttype);
        void AddPackageSeries(PackageSeries packageseries);
        void AddPackage(AdminAddPackageViewModel model);
        void AddPartType(AdminAddParttypwViewModel model);
        void AddPart(Part model);
        void PsDeletePart(int partid);
        void PSsDeletePartType(int id);
        void PSsDeletePackage(int id);
        void PSsDeletePackageSeries(int id);

    }
}
