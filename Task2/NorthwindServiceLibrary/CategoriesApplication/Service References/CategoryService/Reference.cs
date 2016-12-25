﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CategoriesApplication.CategoryService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoryFault", Namespace="http://schemas.datacontract.org/2004/07/NorthwindServiceLibrary.Faults")]
    [System.SerializableAttribute()]
    public partial class CategoryFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId {
            get {
                return this.CategoryIdField;
            }
            set {
                if ((this.CategoryIdField.Equals(value) != true)) {
                    this.CategoryIdField = value;
                    this.RaisePropertyChanged("CategoryId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasicCategory", Namespace="http://schemas.datacontract.org/2004/07/NorthwindModel.Models.CustomModels")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CategoriesApplication.CategoryService.Category))]
    public partial class BasicCategory : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryID {
            get {
                return this.CategoryIDField;
            }
            set {
                if ((this.CategoryIDField.Equals(value) != true)) {
                    this.CategoryIDField = value;
                    this.RaisePropertyChanged("CategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName {
            get {
                return this.CategoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryNameField, value) != true)) {
                    this.CategoryNameField = value;
                    this.RaisePropertyChanged("CategoryName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/NorthwindModel.Models")]
    [System.SerializableAttribute()]
    public partial class Category : CategoriesApplication.CategoryService.BasicCategory {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CategoryService.ICategoryService")]
    public interface ICategoryService {
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (CategoryImage) сообщения CategoryImage не соответствует значению по умолчанию (GetCategoryImage).
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategoryImage", ReplyAction="http://tempuri.org/ICategoryService/GetCategoryImageResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(CategoriesApplication.CategoryService.CategoryFault), Action="http://tempuri.org/ICategoryService/GetCategoryImageCategoryFaultFault", Name="CategoryFault", Namespace="http://schemas.datacontract.org/2004/07/NorthwindServiceLibrary.Faults")]
        CategoriesApplication.CategoryService.CategoryImage GetCategoryImage(CategoriesApplication.CategoryService.CategoryImage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategoryImage", ReplyAction="http://tempuri.org/ICategoryService/GetCategoryImageResponse")]
        System.Threading.Tasks.Task<CategoriesApplication.CategoryService.CategoryImage> GetCategoryImageAsync(CategoriesApplication.CategoryService.CategoryImage request);
        
        // CODEGEN: Контракт генерации сообщений с операцией SetCategoryImage не является ни RPC, ни упакованным документом.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/SetCategoryImage", ReplyAction="http://tempuri.org/ICategoryService/SetCategoryImageResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(CategoriesApplication.CategoryService.CategoryFault), Action="http://tempuri.org/ICategoryService/SetCategoryImageCategoryFaultFault", Name="CategoryFault", Namespace="http://schemas.datacontract.org/2004/07/NorthwindServiceLibrary.Faults")]
        CategoriesApplication.CategoryService.SetCategoryImageResponse SetCategoryImage(CategoriesApplication.CategoryService.CategoryImage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/SetCategoryImage", ReplyAction="http://tempuri.org/ICategoryService/SetCategoryImageResponse")]
        System.Threading.Tasks.Task<CategoriesApplication.CategoryService.SetCategoryImageResponse> SetCategoryImageAsync(CategoriesApplication.CategoryService.CategoryImage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategories", ReplyAction="http://tempuri.org/ICategoryService/GetCategoriesResponse")]
        CategoriesApplication.CategoryService.BasicCategory[] GetCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/GetCategories", ReplyAction="http://tempuri.org/ICategoryService/GetCategoriesResponse")]
        System.Threading.Tasks.Task<CategoriesApplication.CategoryService.BasicCategory[]> GetCategoriesAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CategoryImage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CategoryImage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public int CategoryId;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public int Size;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageStream;
        
        public CategoryImage() {
        }
        
        public CategoryImage(int CategoryId, int Size, System.IO.Stream ImageStream) {
            this.CategoryId = CategoryId;
            this.Size = Size;
            this.ImageStream = ImageStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SetCategoryImageResponse {
        
        public SetCategoryImageResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICategoryServiceChannel : CategoriesApplication.CategoryService.ICategoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CategoryServiceClient : System.ServiceModel.ClientBase<CategoriesApplication.CategoryService.ICategoryService>, CategoriesApplication.CategoryService.ICategoryService {
        
        public CategoryServiceClient() {
        }
        
        public CategoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CategoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CategoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CategoriesApplication.CategoryService.CategoryImage CategoriesApplication.CategoryService.ICategoryService.GetCategoryImage(CategoriesApplication.CategoryService.CategoryImage request) {
            return base.Channel.GetCategoryImage(request);
        }
        
        public void GetCategoryImage(ref int CategoryId, ref int Size, ref System.IO.Stream ImageStream) {
            CategoriesApplication.CategoryService.CategoryImage inValue = new CategoriesApplication.CategoryService.CategoryImage();
            inValue.CategoryId = CategoryId;
            inValue.Size = Size;
            inValue.ImageStream = ImageStream;
            CategoriesApplication.CategoryService.CategoryImage retVal = ((CategoriesApplication.CategoryService.ICategoryService)(this)).GetCategoryImage(inValue);
            CategoryId = retVal.CategoryId;
            Size = retVal.Size;
            ImageStream = retVal.ImageStream;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CategoriesApplication.CategoryService.CategoryImage> CategoriesApplication.CategoryService.ICategoryService.GetCategoryImageAsync(CategoriesApplication.CategoryService.CategoryImage request) {
            return base.Channel.GetCategoryImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<CategoriesApplication.CategoryService.CategoryImage> GetCategoryImageAsync(int CategoryId, int Size, System.IO.Stream ImageStream) {
            CategoriesApplication.CategoryService.CategoryImage inValue = new CategoriesApplication.CategoryService.CategoryImage();
            inValue.CategoryId = CategoryId;
            inValue.Size = Size;
            inValue.ImageStream = ImageStream;
            return ((CategoriesApplication.CategoryService.ICategoryService)(this)).GetCategoryImageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CategoriesApplication.CategoryService.SetCategoryImageResponse CategoriesApplication.CategoryService.ICategoryService.SetCategoryImage(CategoriesApplication.CategoryService.CategoryImage request) {
            return base.Channel.SetCategoryImage(request);
        }
        
        public void SetCategoryImage(int CategoryId, int Size, System.IO.Stream ImageStream) {
            CategoriesApplication.CategoryService.CategoryImage inValue = new CategoriesApplication.CategoryService.CategoryImage();
            inValue.CategoryId = CategoryId;
            inValue.Size = Size;
            inValue.ImageStream = ImageStream;
            CategoriesApplication.CategoryService.SetCategoryImageResponse retVal = ((CategoriesApplication.CategoryService.ICategoryService)(this)).SetCategoryImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CategoriesApplication.CategoryService.SetCategoryImageResponse> CategoriesApplication.CategoryService.ICategoryService.SetCategoryImageAsync(CategoriesApplication.CategoryService.CategoryImage request) {
            return base.Channel.SetCategoryImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<CategoriesApplication.CategoryService.SetCategoryImageResponse> SetCategoryImageAsync(int CategoryId, int Size, System.IO.Stream ImageStream) {
            CategoriesApplication.CategoryService.CategoryImage inValue = new CategoriesApplication.CategoryService.CategoryImage();
            inValue.CategoryId = CategoryId;
            inValue.Size = Size;
            inValue.ImageStream = ImageStream;
            return ((CategoriesApplication.CategoryService.ICategoryService)(this)).SetCategoryImageAsync(inValue);
        }
        
        public CategoriesApplication.CategoryService.BasicCategory[] GetCategories() {
            return base.Channel.GetCategories();
        }
        
        public System.Threading.Tasks.Task<CategoriesApplication.CategoryService.BasicCategory[]> GetCategoriesAsync() {
            return base.Channel.GetCategoriesAsync();
        }
    }
}
