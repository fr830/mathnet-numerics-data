// <copyright file="MatlabReaderTests.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
// Copyright (c) 2009-2010 Math.NET
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System.Numerics;
using MathNet.Numerics.Data.Matlab;
using NUnit.Framework;

namespace MathNet.Numerics.Data.UnitTests.Matlab
{
    /// <summary>
    /// Matlab matrix reader test.
    /// </summary>
    [TestFixture]
    public class MatlabMatrixReaderTests
    {
        /// <summary>
        /// Can read all matrices.
        /// </summary>
        [Test]
        public void CanReadAllMatrices()
        {
            var dmr = new MatlabMatrixReader<double>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(30, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Double.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read first matrix.
        /// </summary>
        [Test]
        public void CanReadFirstMatrix()
        {
            var dmr = new MatlabMatrixReader<double>("./data/Matlab/A.mat");
            var matrix = dmr.ReadMatrix();
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Double.DenseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(100.108979553704, matrix.FrobeniusNorm(), 5);
        }

        /// <summary>
        /// Can read named matrices.
        /// </summary>
        [Test]
        public void CanReadNamedMatrices()
        {
            var dmr = new MatlabMatrixReader<double>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad", "Au64" });
            Assert.AreEqual(2, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Double.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read named matrix.
        /// </summary>
        [Test]
        public void CanReadNamedMatrix()
        {
            var dmr = new MatlabMatrixReader<double>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad" });
            Assert.AreEqual(1, matrices.Count);
            var ad = matrices["Ad"];
            Assert.AreEqual(100, ad.RowCount);
            Assert.AreEqual(100, ad.ColumnCount);
            AssertHelpers.AlmostEqual(100.431635988639, ad.FrobeniusNorm(), 5);
            Assert.AreEqual(typeof(LinearAlgebra.Double.DenseMatrix), ad.GetType());
        }

        /// <summary>
        /// Can read named sparse matrix.
        /// </summary>
        [Test]
        public void CanReadNamedSparseMatrix()
        {
            var dmr = new MatlabMatrixReader<double>("./data/Matlab/sparse-small.mat");
            var matrix = dmr.ReadMatrix("S");
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Double.SparseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(17.6385090630805, matrix.FrobeniusNorm(), 12);
        }
    
            /// <summary>
        /// Can read all complex matrices.
        /// </summary>
        [Test]
        public void CanReadComplexAllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/complex.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(3, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex.DenseMatrix), matrix.Value.GetType());
            }

            var a = matrices["a"];

            Assert.AreEqual(100, a.RowCount);
            Assert.AreEqual(100, a.ColumnCount);
            AssertHelpers.AlmostEqual(27.232498979698409, a.L2Norm(), 15);
        }

        /// <summary>
        /// Can read sparse complex matrices.
        /// </summary>
        [Test]
        public void CanReadSparseComplexAllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/sparse_complex.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(3, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex.SparseMatrix), matrix.Value.GetType());
            }

            var a = matrices["sa"];

            Assert.AreEqual(100, a.RowCount);
            Assert.AreEqual(100, a.ColumnCount);
            AssertHelpers.AlmostEqual(13.223654390985379, a.L2Norm(), 15);
        }

        /// <summary>
        /// Can read non-complex matrices.
        /// </summary>
        [Test]
        public void CanReadNonComplexAllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(30, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read non-complex first matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplexFirstMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/A.mat");
            var matrix = dmr.ReadMatrix();
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Complex.DenseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(100.108979553704, matrix.FrobeniusNorm(), 13);
        }

        /// <summary>
        /// Can read non-complex named matrices.
        /// </summary>
        [Test]
        public void CanReadNonComplexNamedMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad", "Au64" });
            Assert.AreEqual(2, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read non-complex named matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplexNamedMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad" });
            Assert.AreEqual(1, matrices.Count);
            var ad = matrices["Ad"];
            Assert.AreEqual(100, ad.RowCount);
            Assert.AreEqual(100, ad.ColumnCount);
            AssertHelpers.AlmostEqual(100.431635988639, ad.FrobeniusNorm(), 13);
            Assert.AreEqual(typeof(LinearAlgebra.Complex.DenseMatrix), ad.GetType());
        }

        /// <summary>
        /// Can read non-complex named sparse matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplexNamedSparseMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex>("./data/Matlab/sparse-small.mat");
            var matrix = dmr.ReadMatrix("S");
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Complex.SparseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(17.6385090630805, matrix.FrobeniusNorm(), 12);
        }

        /// <summary>
        /// Can read all complex matrices.
        /// </summary>
        [Test]
        public void CanReadComplex32AllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/complex.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(3, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex32.DenseMatrix), matrix.Value.GetType());
            }

            var a = matrices["a"];

            Assert.AreEqual(100, a.RowCount);
            Assert.AreEqual(100, a.ColumnCount);
            AssertHelpers.AlmostEqual(27.232498979698409, a.L2Norm().Real, 6);
        }

        /// <summary>
        /// Can read sparse complex matrices.
        /// </summary>
        [Test]
        public void CanReadSparseComplex32AllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/sparse_complex.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(3, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex32.SparseMatrix), matrix.Value.GetType());
            }

            var a = matrices["sa"];

            Assert.AreEqual(100, a.RowCount);
            Assert.AreEqual(100, a.ColumnCount);
            AssertHelpers.AlmostEqual(13.223654390985379, a.L2Norm().Real, 5);
        }

        /// <summary>
        /// Can read non-complex matrices.
        /// </summary>
        [Test]
        public void CanReadNonComplex32AllMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(30, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex32.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read non-complex first matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplex32FirstMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/A.mat");
            var matrix = dmr.ReadMatrix();
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Complex32.DenseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(100.108979553704, matrix.FrobeniusNorm().Real, 6);
        }

        /// <summary>
        /// Can read non-complex named matrices.
        /// </summary>
        [Test]
        public void CanReadNonComplex32NamedMatrices()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad", "Au64" });
            Assert.AreEqual(2, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Complex32.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read non-complex named matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplex32NamedMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad" });
            Assert.AreEqual(1, matrices.Count);
            var ad = matrices["Ad"];
            Assert.AreEqual(100, ad.RowCount);
            Assert.AreEqual(100, ad.ColumnCount);
            AssertHelpers.AlmostEqual(100.431635988639, ad.FrobeniusNorm().Real, 6);
            Assert.AreEqual(typeof(LinearAlgebra.Complex32.DenseMatrix), ad.GetType());
        }

        /// <summary>
        /// Can read non-complex named sparse matrix.
        /// </summary>
        [Test]
        public void CanReadNonComplex32NamedSparseMatrix()
        {
            var dmr = new MatlabMatrixReader<Complex32>("./data/Matlab/sparse-small.mat");
            var matrix = dmr.ReadMatrix("S");
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Complex32.SparseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(17.6385090630805, matrix.FrobeniusNorm().Real, 6);
        }

        /// <summary>
        /// Can read all matrices.
        /// </summary>
        [Test]
        public void CanReadFloatAllMatrices()
        {
            var dmr = new MatlabMatrixReader<float>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices();
            Assert.AreEqual(30, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Single.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read first matrix.
        /// </summary>
        [Test]
        public void CanReadFloatFirstMatrix()
        {
            var dmr = new MatlabMatrixReader<float>("./data/Matlab/A.mat");
            var matrix = dmr.ReadMatrix();
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Single.DenseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(100.108979553704f, matrix.FrobeniusNorm(), 6);
        }

        /// <summary>
        /// Can read named matrices.
        /// </summary>
        [Test]
        public void CanReadFloatNamedMatrices()
        {
            var dmr = new MatlabMatrixReader<float>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad", "Au64" });
            Assert.AreEqual(2, matrices.Count);
            foreach (var matrix in matrices)
            {
                Assert.AreEqual(typeof(LinearAlgebra.Single.DenseMatrix), matrix.Value.GetType());
            }
        }

        /// <summary>
        /// Can read named matrix.
        /// </summary>
        [Test]
        public void CanReadFloatNamedMatrix()
        {
            var dmr = new MatlabMatrixReader<float>("./data/Matlab/collection.mat");
            var matrices = dmr.ReadMatrices(new[] { "Ad" });
            Assert.AreEqual(1, matrices.Count);
            var ad = matrices["Ad"];
            Assert.AreEqual(100, ad.RowCount);
            Assert.AreEqual(100, ad.ColumnCount);
            AssertHelpers.AlmostEqual(100.431635988639f, ad.FrobeniusNorm(), 6);
            Assert.AreEqual(typeof(LinearAlgebra.Single.DenseMatrix), ad.GetType());
        }

        /// <summary>
        /// Can read named sparse matrix.
        /// </summary>
        [Test]
        public void CanReadFloatNamedSparseMatrix()
        {
            var dmr = new MatlabMatrixReader<float>("./data/Matlab/sparse-small.mat");
            var matrix = dmr.ReadMatrix("S");
            Assert.AreEqual(100, matrix.RowCount);
            Assert.AreEqual(100, matrix.ColumnCount);
            Assert.AreEqual(typeof(LinearAlgebra.Single.SparseMatrix), matrix.GetType());
            AssertHelpers.AlmostEqual(17.6385090630805f, matrix.FrobeniusNorm(), 6);
        }
    }
}
