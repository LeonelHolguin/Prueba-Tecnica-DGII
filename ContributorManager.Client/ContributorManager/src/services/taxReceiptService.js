const BASE_URL = import.meta.env.VITE_BASE_URL;

export const getAllTaxReceipts = async () => {
  const response = await fetch(`${BASE_URL}/TaxReceipt/GetTaxReceipts`);
  const data = await response.json();
  return data;
};
