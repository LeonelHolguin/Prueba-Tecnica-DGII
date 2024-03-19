/* eslint-disable react/prop-types */
import { useEffect, useState } from "react";
import { getAllTaxReceipts } from "../services/taxReceiptService";
import { Modal } from "flowbite-react";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeadCell,
  TableRow,
} from "flowbite-react";

export function TaxReceiptModal({ contributor, onClose }) {
  const [taxReceiptList, setTaxReceiptList] = useState([]);

  let totalITBIS = 0;

  useEffect(() => {
    const getAll = async () => {
      const data = await getAllTaxReceipts();
      setTaxReceiptList(
        data.filter(
          (taxReceipt) =>
            taxReceipt.taxIdentificationNumber ===
            contributor.taxIdentificationNumber
        )
      );
    };
    getAll();
  }, [contributor]);

  const sumITBIS = (itbis) => {
    totalITBIS += itbis;
  };

  return (
    <Modal dismissible show={!!contributor} onClose={onClose}>
      <Modal.Header>
        {contributor.name} - {contributor.type}
      </Modal.Header>
      <Modal.Body>
        <div className="space-y-6 overflow-x-auto">
          <h3 className="dark">Listado de comprobantes fiscales</h3>
          <Table>
            <TableHead>
              <TableHeadCell>NCF</TableHeadCell>
              <TableHeadCell>Monto</TableHeadCell>
              <TableHeadCell>ITBIS 18</TableHeadCell>
            </TableHead>
            <TableBody className="divide-y">
              {taxReceiptList.map((taxReceipt) => (
                <TableRow
                  className="bg-white dark:border-gray-700 dark:bg-gray-800"
                  key={taxReceipt.taxVerificationNumber}
                >
                  <TableCell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                    {taxReceipt.taxVerificationNumber}
                  </TableCell>
                  <TableCell>{taxReceipt.amount}</TableCell>
                  <TableCell>{taxReceipt.vaT18}</TableCell>
                  {sumITBIS(taxReceipt.vaT18)}
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </Modal.Body>
      <Modal.Footer>Total ITBIS: {totalITBIS.toFixed(2)}</Modal.Footer>
    </Modal>
  );
}
