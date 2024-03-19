const BASE_URL = import.meta.env.VITE_BASE_URL;

export const getAllContributors = async () => {
  const response = await fetch(`${BASE_URL}/Contributor/GetContributors`);
  const data = await response.json();
  return data;
};
