using System;

namespace antrl4CS.Nodes
{
    public class TypeNode : AstNode
    {
        /// <summary>
        /// Nombre base del tipo: i, f, b, s o nombre de clase.
        /// </summary>
        public string BaseType { get; set; }

        /// <summary>
        /// Si es un arreglo, aquí se guarda el tamaño (node de expresión).
        /// Si no es arreglo, queda null.
        /// </summary>
        public AstNode ArraySize { get; set; }

        /// <summary>
        /// Si el tipo termina con '?'
        /// </summary>
        public bool IsNullable { get; set; }

        public TypeNode(string baseType, AstNode arraySize = null, bool isNullable = false)
        {
            BaseType = baseType;
            ArraySize = arraySize;
            IsNullable = isNullable;
        }

        public override string ToString()
        {
            var type = BaseType;

            if (ArraySize != null)
                type += $"[{ArraySize}]";

            if (IsNullable)
                type += "?";

            return type;
        }
    }
}
