using ListingApp.DAL;
using ListingApp.DAL.Interfaces;
using ListingApp.DAL.unitOfWork;
using ListingApp.Infrastructure.DTO;
using ListingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace ListingApp.Infrastructure.Services
{
    public class toDoListServices: ItoDoListServices
    {
        private IUnitOfWork _unitOfWork;
        private readonly ItoDoListRepo _listRepo; 
        public toDoListServices(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public List<toDoListDTO> GetAll()
        {
            //return Mapper.Mapper.convert(_listRepo.Getlists());

            List<toDoListDTO> list = new List<toDoListDTO>();
            list = _unitOfWork.toDoListRepo.Getlists();

            return Mapper.convert(list);
        }
        public toDoListDTO Get(int listId)
        {
            var userId = _unitOfWork.toDoListRepo.GetListById(listId);
            return Mapper.Mapper.convert(userId);

        }

        //public string CreateCheque(ChequeTypeDTO Record)
        //{
        //    try
        //    {
        //        ChequeType Data = Mapper.Mapper.convert(Record);
        //        _repo.Insert(Data);
        //        _unitofwork.Save();
        //        return "Cheque Error successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public void insertList(toDoListDTO Record)
        {
            try 
            {
                toDoList list = Mapper.Mapper.convert(Record);
                _unitOfWork.toDoListRepo.InsertList(list);
                _unitOfWork.Save();
               
                
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void createList(toDoListDTO Record)
        {
            throw new NotImplementedException();
        }

        public void updateList(toDoListDTO Record)
        {
            throw new NotImplementedException();
        }

        public bool deleteList(int listID)
        {
            throw new NotImplementedException();
        }

        //    List<toDoListDTO> GetAll();
        //toDoListDTO Get(int listId);
        //string insertList(toDoListDTO Record);
        //string updateList(toDoListDTO Record);
        //bool deleteList(int listID);
    }
}
