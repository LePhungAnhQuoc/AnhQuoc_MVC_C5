using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnhQuoc_MVC_C5
{
    public class UnitOfRepository
    {
        #region SingleTonPattern
        private static readonly object _InstanceLock = new object();

        private static UnitOfRepository _Instance;
        public static UnitOfRepository Instance
        {
            get
            {
                lock (_InstanceLock)
                {
                    if (_Instance == null)
                        _Instance = new UnitOfRepository();
                }
                return _Instance;
            }
        }
        #endregion

        private UnitOfRepository()
        {
        }

        // Others
        private ServerNameRepository _ServerNameRepo;
        public ServerNameRepository ServerNameRepo
        {
            get
            {
                if (_ServerNameRepo == null)
                    _ServerNameRepo = new ServerNameRepository();
                return _ServerNameRepo;
            }
        }

        private DatabaseNameRepository _DatabaseNameRepo;
        public DatabaseNameRepository DatabaseNameRepo
        {
            get
            {
                if (_DatabaseNameRepo == null)
                    _DatabaseNameRepo = new DatabaseNameRepository();
                return _DatabaseNameRepo;
            }
        }

        
        private UserRepository _UserRepo;
        public UserRepository UserRepo
        {
            get
            {
                if (_UserRepo == null)
                {
                    _UserRepo = new UserRepository();
                }
                return _UserRepo;
            }
        }

        private OrderDetailRepository _OrderDetailRepo;
        public OrderDetailRepository OrderDetailRepo
        {
            get
            {
                if (_OrderDetailRepo == null)
                {
                    _OrderDetailRepo = new OrderDetailRepository();
                }
                return _OrderDetailRepo;
            }
        }

        private OrderRepository _OrderRepo;
        public OrderRepository OrderRepo
        {
            get
            {
                if (_OrderRepo == null)
                {
                    _OrderRepo = new OrderRepository();
                }
                return _OrderRepo;
            }
        }

        private ProductRepository _ProductRepo;
        public ProductRepository ProductRepo
        {
            get
            {
                if (_ProductRepo == null)
                {
                    _ProductRepo = new ProductRepository();
                }
                return _ProductRepo;
            }
        }

        private CategoryRepository _CategoryRepo;
        public CategoryRepository CategoryRepo
        {
            get
            {
                if (_CategoryRepo == null)
                {
                    _CategoryRepo = new CategoryRepository();
                }
                return _CategoryRepo;
            }
        }
        
        public void LoadServerNameRepo()
        {
            _ServerNameRepo = new ServerNameRepository();
            _ServerNameRepo.LoadList();

            _DatabaseNameRepo = new DatabaseNameRepository();
            _DatabaseNameRepo.LoadList();
        }

        public void Load()
        {
            _UserRepo = new UserRepository();
            _UserRepo.LoadList();
            _OrderRepo = new OrderRepository();
            _OrderRepo.LoadList();
            _ProductRepo = new ProductRepository();
            _ProductRepo.LoadList();
            _OrderDetailRepo = new OrderDetailRepository();
            _OrderDetailRepo.LoadList();
            _CategoryRepo = new CategoryRepository();
            _CategoryRepo.LoadList();
        }
    }
}
