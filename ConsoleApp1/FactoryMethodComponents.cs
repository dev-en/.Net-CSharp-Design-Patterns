namespace FactoryMethod
{
    /// <summary>
    /// The 'IProduct' interface
    /// </summary>
    interface IProduct
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ProductA : IProduct
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ProductB : IProduct
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    interface ICreator
    {
        public IProduct FactoryMethod();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class CreatorA : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class CreatorB : ICreator
    {
        public IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }
}


