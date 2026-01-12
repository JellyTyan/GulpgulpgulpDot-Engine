using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Gulpgulpgulpdot.SourceGenerators
{
    public readonly struct GulpgulpgulpdotMethodData
    {
        public GulpgulpgulpdotMethodData(IMethodSymbol method, ImmutableArray<MarshalType> paramTypes,
            ImmutableArray<ITypeSymbol> paramTypeSymbols, (MarshalType MarshalType, ITypeSymbol TypeSymbol)? retType)
        {
            Method = method;
            ParamTypes = paramTypes;
            ParamTypeSymbols = paramTypeSymbols;
            RetType = retType;
        }

        public IMethodSymbol Method { get; }
        public ImmutableArray<MarshalType> ParamTypes { get; }
        public ImmutableArray<ITypeSymbol> ParamTypeSymbols { get; }
        public (MarshalType MarshalType, ITypeSymbol TypeSymbol)? RetType { get; }
    }

    public readonly struct GulpgulpgulpdotSignalDelegateData
    {
        public GulpgulpgulpdotSignalDelegateData(string name, INamedTypeSymbol delegateSymbol, GulpgulpgulpdotMethodData invokeMethodData)
        {
            Name = name;
            DelegateSymbol = delegateSymbol;
            InvokeMethodData = invokeMethodData;
        }

        public string Name { get; }
        public INamedTypeSymbol DelegateSymbol { get; }
        public GulpgulpgulpdotMethodData InvokeMethodData { get; }
    }

    public readonly struct GulpgulpgulpdotPropertyData
    {
        public GulpgulpgulpdotPropertyData(IPropertySymbol propertySymbol, MarshalType type)
        {
            PropertySymbol = propertySymbol;
            Type = type;
        }

        public IPropertySymbol PropertySymbol { get; }
        public MarshalType Type { get; }
    }

    public readonly struct GulpgulpgulpdotFieldData
    {
        public GulpgulpgulpdotFieldData(IFieldSymbol fieldSymbol, MarshalType type)
        {
            FieldSymbol = fieldSymbol;
            Type = type;
        }

        public IFieldSymbol FieldSymbol { get; }
        public MarshalType Type { get; }
    }

    public struct GulpgulpgulpdotPropertyOrFieldData
    {
        public GulpgulpgulpdotPropertyOrFieldData(ISymbol symbol, MarshalType type)
        {
            Symbol = symbol;
            Type = type;
        }

        public GulpgulpgulpdotPropertyOrFieldData(GulpgulpgulpdotPropertyData propertyData)
            : this(propertyData.PropertySymbol, propertyData.Type)
        {
        }

        public GulpgulpgulpdotPropertyOrFieldData(GulpgulpgulpdotFieldData fieldData)
            : this(fieldData.FieldSymbol, fieldData.Type)
        {
        }

        public ISymbol Symbol { get; }
        public MarshalType Type { get; }
    }
}
