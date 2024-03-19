import { useEffect, useState } from "react";
import { getAllContributors } from "../services/contributorService";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeadCell,
  TableRow,
} from "flowbite-react";
import { TaxReceiptModal } from "./TaxReceiptModal";

export function TableContainer() {
  const [contributorList, setContributorList] = useState([]);
  const [contributorToShow, setContributorToShow] = useState(null);

  useEffect(() => {
    const getAll = async () => {
      const data = await getAllContributors();
      setContributorList(data);
    };
    getAll();
  }, []);

  const openModal = (contributor) => {
    setContributorToShow(contributor);
  };

  const closeModal = () => {
    setContributorToShow(null);
  };

  return (
    <div className="overflow-x-auto">
      {!contributorList.length > 0 ? (
        <h2>No hay datos aun...</h2>
      ) : (
        <Table hoverable>
          <TableHead>
            <TableHeadCell>rnc/Cedula</TableHeadCell>
            <TableHeadCell>Nombre</TableHeadCell>
            <TableHeadCell>Tipo</TableHeadCell>
            <TableHeadCell>Estado</TableHeadCell>
            <TableHeadCell>
              <span className="sr-only">Edit</span>
            </TableHeadCell>
          </TableHead>
          <TableBody className="divide-y">
            {contributorList.map((contributor) => (
              <TableRow
                className="bg-white dark:border-gray-700 dark:bg-gray-800"
                key={contributor.taxIdentificationNumber}
              >
                <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                  {contributor.taxIdentificationNumber}
                </TableCell>
                <TableCell>{contributor.name}</TableCell>
                <TableCell>{contributor.type}</TableCell>
                <TableCell
                  className={
                    contributor.status === "Activo"
                      ? "text-green-600"
                      : "text-red-600"
                  }
                >
                  {contributor.status}
                </TableCell>
                <TableCell>
                  <button
                    className="font-medium text-cyan-600 hover:underline dark:text-cyan-500 border-none"
                    onClick={() => openModal(contributor)}
                  >
                    Ver detalles
                  </button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      )}
      {contributorToShow && (
        <TaxReceiptModal contributor={contributorToShow} onClose={closeModal} />
      )}
    </div>
  );
}
