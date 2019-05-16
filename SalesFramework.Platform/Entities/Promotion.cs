using SalesFramework.Platform.Entities.EnumeratedTypes;
using SalesFramework.Platform.Model;
using System;
using System.Collections.Generic;

namespace SalesFramework.Platform.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Promotion : Base
    {
        #region Fields
        //The Name field.
        private System.String _name;

        //The Cupom text field.
        private System.String _cupom;

        //The promotion start date field.
        private System.DateTime _startDate;

        //The promotion end date field.
        private System.DateTime _endDate;

        //The condition field.
        private PromotionConditionType _condition;

        //The operator field.
        private PromotionOperatorType _operator;

        //The action field.
        private PromotionActionType _action;

        //The condition arguments field.
        private Dictionary<System.String, System.Object> _conditionArgs;

        //The action arguments field.
        private Dictionary<System.String, System.Object> _actionArgs;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// The default parameterless constructor for the Promotion class.
        /// </summary>
        public Promotion()
        {

        }

        /// <summary>
        /// The default constructor for the Promotion class.
        /// </summary>
        /// <param name="ID">The Promotion ID.</param>
        /// <param name="Name">The Promotion Name.</param>
        /// <param name="Cupom">The Promotion Cupom text if there is one.</param>
        /// <param name="StartDate">The Start Date of the Promotion.</param>
        /// <param name="EndDate">The End Date of the Promotion.</param>
        /// <param name="Condition">The Condition of the Promotion.</param>
        /// <param name="Operator">The Operator of the Promotion.</param>
        /// <param name="Action">The Action of the Promotion.</param>
        /// <param name="ConditionArgs">The Condition Arguments of the Promotion.</param>
        /// <param name="ActionArgs">The Action Arguments of the Promotion.</param>
        public Promotion(System.Int64 ID, System.String Name, System.String Cupom, System.DateTime StartDate, System.DateTime EndDate, PromotionConditionType Condition, PromotionOperatorType Operator, PromotionActionType Action, Dictionary<System.String, System.Object> ConditionArgs, Dictionary<System.String, System.Object> ActionArgs)
        {
            this._ID = ID;
            this._name = Name;
            this._cupom = Cupom;
            this._startDate = StartDate;
            this._endDate = EndDate;
            this._condition = Condition;
            this._operator = Operator;
            this._action = Action;
            this._conditionArgs = ConditionArgs;
            this._actionArgs = ActionArgs;
        }
        #endregion Constructors

        /// <summary>
        /// Gets or sets the valid Name property of the Promotion instance.
        /// </summary>
        public System.String Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._name = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Name can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the valid Cupom property of the Promotion instance.
        /// </summary>
        public System.String Cupom
        {
            get
            {
                return this._cupom;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._cupom = value;
                }
                else
                {
                    throw new InvalidOperationException("Property Cupom can't be null, empty or white space.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                if (value < System.DateTime.Today)
                {
                    this._startDate = value;
                }
                else
                {
                    throw new InvalidOperationException("Property StartDate can't be a date in the past.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public PromotionConditionType Condition
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public PromotionOperatorType Operator
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public PromotionActionType Action
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<System.String, System.Object> ConditionArgs
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<System.String, System.Object> ActionArgs
        {
            get;
            set;
        }


    }
}
