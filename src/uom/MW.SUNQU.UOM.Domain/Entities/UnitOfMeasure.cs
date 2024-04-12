using MW.CHUYA.Domain.Common.Interfaces;
using MW.SUNQU.UOM.Domain.ValueObject;

namespace MW.SUNQU.UOM.Domain.Entities;

public class UnitOfMeasure: IEntity<UnitOfMeasureId>
{
    public UnitOfMeasureId? Id { get; set; }
    public string Description { get; set; }
    public string Abbreviation { get; set; }
    public float? NumericalVaue { get; set; }
    public UnitOfMeasureId? BaseUnit { get; set; }

    #region Contructor
    private UnitOfMeasure(
        string description,
        string abbreviation)
    {
        Description = description;
        Abbreviation = abbreviation;
    }
    #endregion

    /// <summary>
    /// Builder for Unit of Measurement
    /// </summary>
    public class Builder
    {
        #region Properties & Variables
        //
        // private
        //
        private UnitOfMeasure _unitOfMeasure = new(string.Empty, string.Empty);
        #endregion

        #region Constructor
        public Builder()
        {
            Reset();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Build a unit of measure
        /// </summary>
        /// <returns>Instance of <see cref="UnitOfMeasure"/></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public UnitOfMeasure Build()
        {
            if (string.IsNullOrWhiteSpace(_unitOfMeasure.Description) ||
                string.IsNullOrWhiteSpace(_unitOfMeasure.Abbreviation))
                throw new InvalidOperationException("La descripción y la abreviatura son obligatorios.");

            UnitOfMeasure unitOfMeasure = _unitOfMeasure;
            Reset();
            return unitOfMeasure;
        }

        public void Reset()
        {
            _unitOfMeasure = new UnitOfMeasure(string.Empty, string.Empty);
        }

        public void WithAbbreviation(string abbreviation)
        {
            _unitOfMeasure.Abbreviation = abbreviation;
        }

        public void WithBaseUnit(UnitOfMeasureId? baseUnitId)
        {
            _unitOfMeasure.BaseUnit = baseUnitId;
        }

        public void WithDescription(string description)
        {
            _unitOfMeasure.Description = description;
        }

        public void WithNumericalValue(float? numericalValue)
        {
            _unitOfMeasure.NumericalVaue = numericalValue;
        }
        #endregion
    }
}
