using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ProdBuilder0920.DataService;
using ProdBuilder0920.Domain;
using ProdBuilder0920.Domain.ViewModels;
using ProdBuilder0920.Service;

namespace ProdBuilder0920.web
{
    public class ProductServiceRepository: IProductServiceRepository
    {
        readonly AppContext _context = new AppContext();

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetOrders(string username)
        {
            return _context.Orders.Where(m => m.UsernameCustomer == username).ToList();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.SingleOrDefault(m => m.OrderID == id);
        }

        public void UpdateOrderStatus(Order model)
        {
            var res = _context.Orders.SingleOrDefault(m => m.OrderID == model.OrderID);
            res.OrderID = model.OrderID;
            res.OrderStatus = model.OrderStatus;
            _context.Orders.AddOrUpdate(res);
            _context.SaveChanges();
        }

        public void WriteOrder(List<Part> cartList, int id, string user, int packetPrice)
        {
            var neworder = new Order();
            neworder.OrderNr = GetProdCode(cartList);
            neworder.OrderlSum = GetPriceForParts(cartList) + packetPrice;
            neworder.OrderPlaced = DateTime.Now;
            neworder.OrderDeliveryDate = LatestDate(cartList);
            neworder.PackageId = id;
            neworder.UsernameCustomer = user;
            neworder.OrderStatus = OrderStatus.NewOrder;

            _context.Orders.Add(neworder);
            _context.SaveChanges();

        }

        public DateTime LatestDate(List<Part> cartList)
        {
            var latestDate = cartList.OrderByDescending(m => m.PartDeliverytime).FirstOrDefault();
            return latestDate.PartDeliverytime;
        }

        public string GetProdCode(List<Part> cartList)
        {
            string orderProdCode = null;

            foreach (var item in cartList)
            {
                orderProdCode += item.PartProductionCode;
            }
            return orderProdCode;
        }

        public int GetPriceForParts(List<Part> cartList)
        {
            int orderprice = 0;

            foreach (var part in cartList)
            {
                orderprice += part.PartPrice;
            }
            return orderprice;
        }

        public List<PackageSeries> GetAllPackageSeries()
        {
            return _context.PackageSeries.ToList();
        }

        public PackageSeries GetAPackageSeries(int id)
        {
            return _context.PackageSeries.SingleOrDefault(m => m.PackageSeriesId == id);
        }

        public void UpdateSeries(PackageSeries model)
        {
            var res = _context.PackageSeries.SingleOrDefault(m => m.PackageSeriesId == model.PackageSeriesId);
            res.PackageSeriesName = model.PackageSeriesName;
            _context.PackageSeries.AddOrUpdate(res);
            _context.SaveChanges();
        }

        public void UpdatePackage(Package model)
        {
            var res = _context.Packages.SingleOrDefault(m => m.PackageID == model.PackageID);
            res.PackageName = model.PackageName;
            res.PackageDescription = model.PackageDescription;
            res.PackageStartPrice = model.PackageStartPrice;
            res.PackageProductionCode = model.PackageProductionCode;
            res.PackageImageUrl = model.PackageImageUrl;
            res.PackageSeriesId = model.PackageSeriesId;
            res.PackageID = model.PackageID;

            _context.Packages.AddOrUpdate(res);
            _context.SaveChanges();

        }

        public void UpdatePArtType(PartType model)
        {
            var res = _context.PartTypes.SingleOrDefault(m => m.PartTypeID == model.PartTypeID);
            res.PartTypeName = model.PartTypeName;
            res.PackageId = model.PackageId;
            res.PartTypeID = model.PartTypeID;
            res.PartTypeImageUrl = model.PartTypeImageUrl;

            _context.PartTypes.AddOrUpdate(res);
            _context.SaveChanges();
        }

        public void UpdatePart(Part model)
        {
            var res = _context.Parts.SingleOrDefault(m => m.PartID == model.PartID);
            res.PartModelName = model.PartModelName;
            res.PartDeliverytime = model.PartDeliverytime;
            res.PartDescription = model.PartDescription;
            res.PartID = model.PartID;
            res.PartTypeId = model.PartTypeId;
            res.PartImageUrl = model.PartImageUrl;
            res.PartPrice = model.PartPrice;
            res.PartManufacturer = model.PartManufacturer;
            res.PartProductionCode = model.PartProductionCode;

            _context.Parts.AddOrUpdate(res);
            _context.SaveChanges();
        }

        public List<Package> GetAllPackages_()
        {
            return _context.Packages.ToList();
        }

        public List<Package> GetAllPackages(int id)
        {
            return _context.Packages.Where(m => m.PackageSeriesId == id).OrderByDescending(x => x.PackageStartPrice).ToList();

        }

        public Package GetAPackage(int id)
        {
            return _context.Packages.SingleOrDefault(m => m.PackageID == id);
        }

        public List<Part> GetAllParts()
        {
            return _context.Parts.OrderBy(m => m.PartProductionCode).ToList(); ;

        }

        public List<PartType> GetAllPartTypes()
        {
            return _context.PartTypes.ToList();
        }

        public PartType GetAPartType(int id)
        {
            return _context.PartTypes.SingleOrDefault(m => m.PartTypeID == id);

        }

        public List<PartType> GetPartTypes(int id)
        {
            return _context.PartTypes.Where(m => m.Package.PackageID == id).OrderBy(m => m.PartTypeName).ToList();
            
        }

        public List<Part> GetParts(int id)
        {
            return _context.Parts.Where(m => m.PartTypeId == id).ToList();
        }

        public Part GetPart(int id)
        {
            return _context.Parts.SingleOrDefault(m => m.PartID == id);
            
        }

        public List<PartType> GetParttypesAndParts(int id)
        {
            return _context.PartTypes.Where(m => m.PackageId == id).Include(m => m.Parts).OrderBy(m => m.PartTypeName).ToList();
        }

        public Part GetPartTypeAndPart(int id)
        {
            return _context.Parts.Include(m => m.PartType).SingleOrDefault(m => m.PartID == id);
        }

        public bool GetCartStatus(List<Part> list, Part parttype)
        {
            return list.Any(m => m.PartType.PartTypeID == parttype.PartTypeId);
        }

        public void AddPackageSeries(PackageSeries packageseries)
        {
            var newseries = new PackageSeries();
            {
                newseries.PackageSeriesName = packageseries.PackageSeriesName;
                //newseries.PackageSeriesId = packageseries.PackageSeriesId;
                _context.PackageSeries.Add(newseries);
                _context.SaveChanges();
            };
        }

        public void AddPackage(AdminAddPackageViewModel model)
        {
            var package = new Package();
            {
                package.PackageName = model.PackageName;
                package.PackageStartPrice = model.PackageStartPrice;
                package.PackageDescription = model.PackageDescription;
                package.PackageImageUrl = model.PackageImageUrl;
                package.PackageProductionCode = model.PackageProductionCode;
                package.PackageSeriesId = model.PackageSeriess;
                _context.Packages.Add(package);
                _context.SaveChanges();
            };
        }

        public void AddPartType(AdminAddParttypwViewModel model)
        {
            var res = new PartType();
            {
                res.PartTypeName = model.PartTypeName;
                res.PackageId = model.Partss;
                res.PartTypeImageUrl = model.PartTypeImageUrl;
                _context.PartTypes.Add(res);
                _context.SaveChanges();
            };
        }

        public void AddPart(Part model)
        {
            var res = new Part();
            {
                res.PartManufacturer = model.PartManufacturer;
                res.PartModelName = model.PartModelName;
                res.PartTypeId = model.PartTypeId;
                res.PartProductionCode = model.PartProductionCode;
                res.PartDescription = model.PartDescription;
                res.PartPrice = model.PartPrice;
                res.PartDeliverytime = model.PartDeliverytime;
                res.PartImageUrl = model.PartImageUrl;
                _context.Parts.Add(res);
                _context.SaveChanges();
            };
        }

        public void PsDeletePart(int partid)
        {
            var partToRemove = _context.Parts.SingleOrDefault(m => m.PartID == partid);
            if (partToRemove != null)
            {
                _context.Parts.Remove(partToRemove);
                _context.SaveChanges();
            }
        }

        public void PSsDeletePartType(int id)
        {
            var PartsToRemove = _context.Parts.Where(m => m.PartTypeId == id).ToList();
            var PartTypeToRemove = _context.PartTypes.SingleOrDefault(m => m.PartTypeID == id);

            if (PartTypeToRemove != null)
            {
                _context.Parts.RemoveRange(PartsToRemove);
                _context.PartTypes.Remove(PartTypeToRemove);
                _context.SaveChanges();
            }
        }

        public void PSsDeletePackage(int id)
        {
            var partTypesToRemove = _context.PartTypes.Where(m => m.PackageId == id).ToList();
            var packageToRemove = _context.Packages.SingleOrDefault(m => m.PackageID == id);
            var listofparttypeid = new List<int>();
            var partsToRemove = new List<Part>();

            foreach (var item in partTypesToRemove)
            {
                partsToRemove = _context.Parts.Where(m => m.PartTypeId == item.PartTypeID).ToList();
            }

            if (packageToRemove != null)
            {
                _context.Parts.RemoveRange(partsToRemove);
                _context.PartTypes.RemoveRange(partTypesToRemove);
                _context.Packages.Remove(packageToRemove);
                _context.SaveChanges();
            }
        }

        public void  PSsDeletePackageSeries(int id)
        {
            var seriesId = _context.PackageSeries.SingleOrDefault(m => m.PackageSeriesId == id);
            var packages = _context.Packages.Where(m => m.PackageSeriesId == id).ToList();

            _context.Packages.RemoveRange(packages);
            _context.PackageSeries.Remove(seriesId);
            _context.SaveChanges();
        }
    }
}